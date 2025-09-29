using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ISIP523_Ilyamakov
{
    class Text
    {
        public string text;
        public string[] words;
        public List<string> statistics;
        public List<char> letters;
        public List<int> lettersStatics;

        public Text(string text)
        {
            this.text = text;
            this.statistics = new List<string>();
            this.letters = new List<char>();
            this.lettersStatics = new List<int>();

            this.words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            statistics.Add("Кол-во слов: " + Convert.ToString(words.Length));

            string[] sentences = text.Split(new char[] { '.' });
            statistics.Add("Кол-во предложений: " + Convert.ToString(sentences.Length));

            string shortles = "";
            string longest = "";
            foreach (string word in words)
            {
                if (word.Length > longest.Length) longest = word;
                else if (word.Length < shortles.Length) shortles = word;
            }
            statistics.Add("Самое короткое слово: " + shortles);
            statistics.Add("Самое длинное слово: " + longest);
        }
    }
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


            bool inMenu = true;
            while (inMenu)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("0. Выход");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------");
                switch(choice)
                {
                    case 0: inMenu = false; break;
                }
            }
        }
    }
}
