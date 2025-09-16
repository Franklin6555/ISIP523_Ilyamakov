using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Ilyamakov
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool in_menu = true;
            while (in_menu)
            {
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Вывод данных");
                Console.WriteLine("2. Статистика");
                Console.WriteLine("3. Сортировка по цене");
                Console.WriteLine("4. Конвертация валюты");
                Console.WriteLine("5. Поиск по названию");
                Console.WriteLine("0. Выход");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        in_menu = false; 
                        break;
                    case 1:
                        //Input();
                        break;
                    case 2:
                        //GetStats();
                        break;
                    case 3:
                        //Sorted;
                        break;
                    case 4:
                        //ConvertC();
                        break;
                    case 5:
                        //Search();
                        break;
                }
                    
            }

        }
    }
}
