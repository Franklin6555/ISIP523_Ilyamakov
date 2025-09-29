using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ISIP523_Ilyamakov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool inputCheck = false;
            while (!inputCheck) 
            {
                Console.WriteLine("Введите текст (минимум 100 символов)");
                Console.WriteLine("------------------------------------");
                string text = Console.ReadLine();
                if (text.Length > 100) inputCheck = true;
                else Console.WriteLine("МИНИМУМ 100 СИМВОЛОВ");
                Console.WriteLine("------------------------------------");
            }
            bool inMenu = true;
            while (inMenu)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Вывод данных");
                Console.WriteLine("2. Статистика");
                Console.WriteLine("3. Сортировка по убыванию цены");
                Console.WriteLine("4. Конвертация валюты");
                Console.WriteLine("5. Поиск по названию");
                Console.WriteLine("0. Выход");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------");
            }
        }
        
    }
}
