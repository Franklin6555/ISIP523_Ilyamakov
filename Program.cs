using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            int amt = 1;
            Console.WriteLine("Введите кол-во операций, которые будут записаны (от 2 до 40):");
            amt = Convert.ToInt32(Console.ReadLine());
            string[] names = new string[amt];
            double[] prices = new double[amt];
            for (int i = 0; i < amt; i++)
            {
                Console.WriteLine("Введите название товара/услуги и цену (в формате название;цена)");
                string input = Console.ReadLine();
                string[] inputSplited = input.Split(new char[] { ';' });
                names[i] = inputSplited[0];
                prices[i] = Convert.ToDouble(inputSplited[1]);
            }
            bool in_menu = true;
            while (in_menu)
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
                double mean = 0;
                double max = 0;
                double min = 0;
                double sum = 0;
                switch (choice)
                {
                    case 0:
                        in_menu = false; 
                        break;
                    case 1:
                        for (int i = 0; i < amt; i++)
                        {
                            Console.WriteLine(names[i] + ";" + prices[i] + "руб.");
                        }
                        break;
                    case 2:
                        foreach (double i in prices)
                        {
                            sum += i;
                            if (i > max) max = i;
                            if (i < min) min = i;
                        }
                        mean = sum / amt;
                        Console.WriteLine("Среднее: " + mean);
                        Console.WriteLine("Максимальное: " + max);
                        Console.WriteLine("Минимальное: " + max);
                        Console.WriteLine("Сумма: " + sum);
                        break;
                    case 3:
                        for (int i = 1; i < amt; i++)
                        {
                            if (prices[i] > prices[i - 1])
                            {
                                double tmpPrice = prices[i];
                                string tmpName = names[i];
                                prices[i] = prices[i - 1];
                                names[i] = names[i - 1];
                                prices[i - 1] = tmpPrice;
                                names[i - 1] = tmpName;
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Выберите валюту:");
                        Console.WriteLine("1. В доллары");
                        Console.WriteLine("2. В евро");
                        int cur = Convert.ToInt32(Console.ReadLine());
                        for (int i = 1; i < amt; i++)
                        {
                            if (cur == 1) Console.WriteLine(names[i] + ";" + prices[i] / 83);
                            if (cur == 2) Console.WriteLine(names[i] + ";" + prices[i] / 98);
                        }
                        break;
                    case 5:
                        //Search();
                        break;
                }
                    
            }

        }
    }
}
