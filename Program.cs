using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Ilyamakov
{
    enum Category
    {
        Dairy = 1,
        Canned,
        Bakery
    }
    class Product
    {
        public int ID;
        public string Name;
        public double Price;
        public int Quantity;
        public bool Have;
        public Category Category;
        public Product(int id, string name, double price, int quantity, Category category)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            if (quantity > 0) this.Have = true;
            else Have = false;
            this.Category = category;
        }
        public void PrintInfo()
        {
            Console.WriteLine($" ID: {ID} \n Имя: {Name} \n Цена: {Price}");
            if (Have) Console.WriteLine("Quantity: ", Quantity);
            else Console.WriteLine("Do not have");

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
        }
    }
}
