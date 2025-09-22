using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Ilyamakov
{
    class Product
    {
        public static int ID;
        public string Name;
        public double Price;
        public int Quantity;
        public bool Have;
        public Product(string name, double price, int quantity)
        {
            ID += 1;
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            if (quantity > 0) Have = true;
            else Have = false;
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

        }
    }
}
