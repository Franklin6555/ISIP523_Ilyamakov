using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ISIP523_Ilyamakov
{
    class TextStatistic
    {
        public int id;
        public string name;
        public string text;
        public string[] words;
        public List<string> statistics;
        public Dictionary<char, int> lettersStatics;

        public TextStatistic(string text, int id)
        {
            this.id = id;
            this.text = text;
            this.statistics = new List<string>();
            this.lettersStatics = new Dictionary<char, int>();

            this.words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            statistics.Add("Кол-во слов: " + Convert.ToString(words.Length));

            this.name = $"{words[0]} {words[1]} {words[2]}";

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

            string lowerText = text.ToLower();
            foreach(char letter in lowerText)
            {
                if (lettersStatics.ContainsKey(letter))
                {
                    lettersStatics[letter]++;
                }
                else
                {
                    lettersStatics.Add(letter, 1);
                }
            }
        }
    }
    internal class Program
    {
        static int gid = 1;
        static List<TextStatistic> texts = new List<TextStatistic>();
        static int currentTextId = 0;
        static void Main(string[] args)
        {
            AddText();

            bool inMenu = true;
            while (inMenu)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Добавить новый текст");
                Console.WriteLine("2. Вывести список тектов");
                Console.WriteLine("0. Выход");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------");
                switch(choice)
                {
                    case 0: inMenu = false; break;
                    case 1: AddText(); break;
                    case 2: TextList(); break;
                }
            }
        }
        static void AddText()
        {
            bool inputCheck = false;
            Console.WriteLine("Введите текст (минимум 100 символов)");
            Console.WriteLine("------------------------------------");
            while (!inputCheck)
            {
                string text = Console.ReadLine();
                if (text.Length > 100)
                {
                    inputCheck = true;
                    texts.Add(new TextStatistic(text, gid++));
                    currentTextId++;
                }
                else Console.WriteLine("МИНИМУМ 100 СИМВОЛОВ");
                Console.WriteLine("------------------------------------");
            }
            Console.WriteLine("Успешно!");
            Console.WriteLine("------------------------------------");
        }
        static void TextList()
        {
            foreach (TextStatistic text in texts)
            {
                Console.WriteLine(text.id + ". " + text.name);
            }
        }
    }
}
