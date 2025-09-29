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
            Console.WriteLine("Введите текст (минимум 100 символов)");
            Console.WriteLine("------------------------------------");
            string text = Console.ReadLine();
            while (!inputCheck) 
            {
                if (text.Length > 100) inputCheck = true;
                else Console.WriteLine("МИНИМУМ 100 СИМВОЛОВ");
                Console.WriteLine("------------------------------------");
            }

            List<string> statistics = new List<string>();

            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string wordsCount = "Кол-во слов: " + Convert.ToString(words.Length);
            statistics.Add(wordsCount);

            string[] sentences = text.Split(new char[] { '.' });
            string sentencesCount = "Кол-во предложений: " + Convert.ToString(sentences.Length);
            statistics.Add(sentencesCount);

            bool inMenu = true;
            while (inMenu)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("0. Выход");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------");
            }
        }
        
    }
}
