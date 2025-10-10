using System;
using System.Collections.Generic;
using System.Linq;
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
                Console.WriteLine("0. Вывести кол-во книг у каждого автора");
                Console.WriteLine("------------------------------------");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------");
                switch (choice)
                {
                    case 0: in_menu = false; break;
                    case 1: AddBook(); break;
                    case 2: DelBook(); break;
                    case 3: SearchProduct(); break;
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
        static void SearchProduct()
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
                    var bookSearchName = books.Where(b => b.name.Contains(nameSearch));
                    Console.WriteLine("Результат: ");
                    foreach (var b in bookSearchName)
                    {
                        b.PrintInfo();
                    }
                    break;
                case 3:
                    Console.WriteLine("Введите категорию (1 - Фентези, 2 - Детектив, 3 - Антиутопия, 4 - Другое):");
                    int ganreSearch = Convert.ToInt32(Console.ReadLine());
                    var bookSearchGanre = books.Where(b => b.ganre == (Ganre)ganreSearch);
                    Console.WriteLine("Результат: ");
                    foreach (var b in bookSearchGanre)
                    {
                        b.PrintInfo();
                    }
                    break;
                case 4:
                    Console.WriteLine("Введи строку для поиска: ");
                    string authorSearch = Console.ReadLine();
                    var bookSearchAuthor = books.Where(b => b.author.Contains(authorSearch));
                    Console.WriteLine("Результат: ");
                    foreach (var b in bookSearchAuthor)
                    {
                        b.PrintInfo();
                    }
                    break;
                case 5:
                    Console.WriteLine("Введи год: ");
                    int yearSearch = Convert.ToInt32(Console.ReadLine());
                    var bookSearchYear = books.Where(b => b.year == yearSearch);
                    Console.WriteLine("Результат: ");
                    foreach (var b in bookSearchYear)
                    {
                        b.PrintInfo();
                    }
                    break;
                case 6:
                    Console.WriteLine("Введи минимальную цену:");
                    double minPrice = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Введи максимальную цену:");
                    double maxPrice = Convert.ToDouble(Console.ReadLine());
                    
                    var bookSearchPrice = books.Where(b => b.price <= minPrice && b.price <= maxPrice).OrderBy(b => b.price);

                    Console.WriteLine("Результат: ");
                    foreach (var b in bookSearchPrice)
                    {
                        b.PrintInfo();
                    }
                    break;
            }
        }
    }
}