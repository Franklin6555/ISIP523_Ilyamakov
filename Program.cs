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
                }
            }
        }
        static void AddBook()
        {
            gid++;
            Console.WriteLine("Название:");
            string nm = Console.ReadLine();
            Console.WriteLine("Название:");
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
    }
}
