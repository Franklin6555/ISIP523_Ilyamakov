using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
                        Console.WriteLine("Введите кол-во операций, которые будут записаны (от 2 до 40):");
                        int amt = Convert.ToInt32(Console.ReadLine());
                        string[] names = new string[amt];
                        int[] prices = new int[amt];
                        for (int i = 0; i < amt; i++)
                        {
                            Console.WriteLine("Введите название товара/услуги и цену (в формате название;цена)");
                            string input = Console.ReadLine();
                            string[] inputSplited = input.Split(new char[] { ';' });
                            names[i] = inputSplited[0];
                            prices[i] = Convert.ToInt32(inputSplited[1]);
                        }
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
