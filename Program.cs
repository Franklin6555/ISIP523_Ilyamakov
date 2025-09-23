using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Ilyamakov
{
    enum Categories
    {
        Молочка = 1,
        Консервы,
        Хлебобулочное,
        Другое
    }
    class Product
    {
        public int id;
        public string name;
        public double price;
        public int quantity;
        public bool have;
        public Categories category;
        public Product(int id, string name, double price, int quantity, int categoryNum)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            if (quantity > 0) this.have = true;
            else have = false;

            if (categoryNum < 5) this.category = (Categories)categoryNum;
            else
            {
                Console.WriteLine("Неизветсная категория \nУстановлена категория 'Другое'");
                this.category = (Categories)4;
            }
        }
        public void PrintInfo()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"ID: {id} \nИмя: {name} \nЦена: {price}");
            if (have) Console.WriteLine($"Кол-во: {quantity}");
            else Console.WriteLine("Нет на складе");
            Console.WriteLine($"Категория: {category}");
            Console.WriteLine("------------------------------------");

        }
    }
    internal class Program
    {
        static List<Product> products = new List<Product>();
        static int gid = 1;
        static void Main(string[] args)
        {
            bool in_menu = true;
            
            while (in_menu)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Добавить товар");
                Console.WriteLine("2. Удалить товар");
                Console.WriteLine("3. Заказать поставку товара");
                Console.WriteLine("4. Продать товар");
                Console.WriteLine("5. Поиск товаров ");
                Console.WriteLine("0. Выход");
                Console.WriteLine("------------------------------------");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------");
                switch (choice)
                {
                    case 0: in_menu = false; break;
                    case 1: AddProduct(); break;
                    case 2: DelProduct(); break;
                    case 5: SearchProduct(); break;
                }
            }
        }

        static void AddProduct()
        {
            Console.WriteLine("Ведите кол-во товаров:");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++, gid++)
            {
                Console.WriteLine("Название:");
                string nm = Console.ReadLine();
                Console.WriteLine("Цена:");
                double p = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Кол-во:");
                int q = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Категория (1 - Молочные, 2 - Консервированые, 3 - Хлебобулочные, 4 - другое");
                int c = Convert.ToInt32(Console.ReadLine());
                products.Add(new Product(gid, nm, p, q, c));
            }
        }
        static void DelProduct()
        {
            Console.WriteLine("Введите ID товара который необходимо удалить");
            int delId = Convert.ToInt32(Console.ReadLine());
            products.RemoveAll(n => n.id == delId);
        }
        static void SearchProduct()
        {
            Console.WriteLine("Введи строку для поиска: ");
            string search = Console.ReadLine();
            Console.WriteLine("Результат: ");
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].name.Contains(search)) products[i].PrintInfo();
            }
        }
    }
}
