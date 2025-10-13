using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ISIP523_Ilyamakov
{
    enum Ganre
    {
        Фентези = 1,
        Детектив,
        Антиутопия,
        Другое
    }
    class Book
    {
        public int id;
        public string name;
        public string author;
        public int year;
        public double price;
        public Ganre ganre;

        public Book(int id, string name, string author, int ganreNum, int year, double price)
        {
            this.id = id;
            this.year = year;

            if (author == null)
            {
                Console.WriteLine($"Автор не может быть пустым \nНазначен автор 'Неизваетен'");
                this.author = "Неизваетен";
            }
            else this.author = author;

            if (name == null)
            {
                Console.WriteLine($"Название не может быть пустым \nНазначено название 'Книга {id}'");
                this.name = "Книга " + Convert.ToString(id);
            }
            else this.name = name;

            if (price < 0)
            {
                Console.WriteLine("Цена не может быть отрицательной \nНазначена цена 0");
                this.price = 0;
            }
            else this.price = price;

            if (ganreNum < 5) this.ganre = (Ganre)ganreNum;
            else
            {
                Console.WriteLine("Неизветсный жанр \nНазначен жанр 'Другое'");
                this.ganre = (Ganre)4;
            }
        }
        public void PrintInfo()
        {
            Console.WriteLine($"ID: {id} \nНазвание: {name} \nАвтор: {author} \nГод: {year} \n:Жанр: {ganre}\nЦена: {price}");
            Console.WriteLine("------------------------------------");
        }
    }

    internal class Program
    {
        static int gid = 0;
        static List<Book> books = new List<Book>();
        static void Main(string[] args)
        {
            bool in_menu = true;

            while (in_menu)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Удалить книгу по ID");
                Console.WriteLine("3. Найти книги");
                Console.WriteLine("4. Отсортировать книги");
                Console.WriteLine("5. Вывести самую дорогую и самую дешёвую книгу ");
                Console.WriteLine("6. Вывести кол-во книг у каждого автора");
                Console.WriteLine("0. Выход");
                Console.WriteLine("------------------------------------");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------");
                switch (choice)
                {
                    case 0: in_menu = false; break;
                    case 1: AddBook(); break;
                    case 2: DelBook(); break;
                    case 3: SearchBook(); break;
                    case 4: SortBook(); break;
                    case 5: MinMaxBook(); break;
                }
            }
        }
        static void AddBook()
        {
            gid++;
            Console.WriteLine("Название:");
            string nm = Console.ReadLine();
            Console.WriteLine("Автор:");
            string au = Console.ReadLine();
            Console.WriteLine("Жанр (1 - Фентези, 2 - Детектив, 3 - Антиутопия, 4 - Другое)");
            int gn = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Год:");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Цена:");
            double p = Convert.ToDouble(Console.ReadLine());
            books.Add(new Book(gid, nm, au, gn, y, p));
            Console.WriteLine("------------------------------------");
        }
        static void DelBook()
        {
            Console.WriteLine("Введите ID книги которую необходимо удалить");
            int delId = Convert.ToInt32(Console.ReadLine());
            books.RemoveAll(n => n.id == delId);
        }
        static void PrintAllBooks(List<Book> BookList)
        {
            foreach (var b in BookList)
            {
                b.PrintInfo();
            }
        }
        static void SearchBook()
        {
            Console.WriteLine("Выберете параметр поиска (1 - id; 2 - название; 3 - Жанр; 4 - Автор; 5 - Год; 6 - Цена)");
            int searchType = Convert.ToInt32(Console.ReadLine());
            switch (searchType)
            {
                case 1:
                    Console.WriteLine("Введи id для поиска: ");
                    int idSearch = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Результат: ");
                    try
                    {
                        books.Find(b => b.id == idSearch).PrintInfo();
                    }
                    catch
                    {
                        Console.WriteLine("Нет товара с таким ID");
                    }
                    break;
                case 2:
                    Console.WriteLine("Введи строку для поиска: ");
                    string nameSearch = Console.ReadLine();

                    List<Book> bookSearchName = (List<Book>)books.Where(b => b.name.Contains(nameSearch));

                    Console.WriteLine("Результат: ");
                    PrintAllBooks(bookSearchName);
                    break;
                case 3:
                    Console.WriteLine("Введите категорию (1 - Фентези, 2 - Детектив, 3 - Антиутопия, 4 - Другое):");
                    int ganreSearch = Convert.ToInt32(Console.ReadLine());

                    List<Book> bookSearchGanre = (List<Book>)books.Where(b => b.ganre == (Ganre)ganreSearch);

                    Console.WriteLine("Результат: ");
                    PrintAllBooks(bookSearchGanre);
                    break;
                case 4:
                    Console.WriteLine("Введи строку для поиска: ");
                    string authorSearch = Console.ReadLine();

                    List<Book> bookSearchAuthor = (List<Book>)books.Where(b => b.author.Contains(authorSearch));

                    Console.WriteLine("Результат: ");
                    PrintAllBooks(bookSearchAuthor);
                    break;
                case 5:
                    Console.WriteLine("Введи год: ");
                    int yearSearch = Convert.ToInt32(Console.ReadLine());

                    List<Book> bookSearchYear = (List<Book>)books.Where(b => b.year == yearSearch);

                    Console.WriteLine("Результат: ");
                    PrintAllBooks(bookSearchYear);
                    break;
                case 6:
                    Console.WriteLine("Введи минимальную цену:");
                    double minPrice = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Введи максимальную цену:");
                    double maxPrice = Convert.ToDouble(Console.ReadLine());

                    List<Book> bookSearchPrice = (List<Book>)books.Where(b => b.price <= minPrice && b.price <= maxPrice).OrderBy(b => b.price);

                    Console.WriteLine("Результат: ");
                    PrintAllBooks(bookSearchPrice);
                    break;
            }
        }
        static void SortBook()
        {
            Console.WriteLine("Выберете вид сортировки: ");
            Console.WriteLine("1 - Название (Возрастание)");
            Console.WriteLine("2 - Цена (Возрастание)");
            Console.WriteLine("3 - Название (Убывание)");
            Console.WriteLine("4 - Цена (Убывание)");
            int sortType = Convert.ToInt32(Console.ReadLine());

            switch (sortType)
            {
                case 1:
                    List<Book> bookSortedName1 = (List<Book>)books.OrderBy(b => b.name);
                    PrintAllBooks(bookSortedName1);
                    break;
                case 2:
                    List<Book> bookSortedYear1 = (List<Book>)books.OrderBy(b => b.year);
                    PrintAllBooks(bookSortedYear1);
                    break;
                case 3:
                    List<Book> bookSortedName2 = (List<Book>)books.OrderByDescending(b => b.name);
                    PrintAllBooks(bookSortedName2);
                    break;
                case 4:
                    List<Book> bookSortedYear2 = (List<Book>)books.OrderByDescending(b => b.year);
                    PrintAllBooks(bookSortedYear2);
                    break;
            }
        }
        static void MinMaxBook()
        {
            Console.WriteLine("Самая дешёвая книга:");
            books.Find(b => b.price == books.Min(x => x.price)).PrintInfo();
            Console.WriteLine("Самая дорогая книга:");
            books.Find(b => b.price == books.Max(x => x.price)).PrintInfo();
        }
    }
}