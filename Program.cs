using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }

    internal class Program
    {
        static int gid = 0;
        static List<Book> books = new List<Book>();
        static void Main(string[] args)
        {
            
        }
    }
}
