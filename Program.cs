using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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
        public List<string> statistics;
        public Dictionary<char, int> lettersStatics;

        public TextStatistic(string text, int id)
        {

            List<char> vowels = new List<char>() { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            List<char> consonants = new List<char>() { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };

            this.id = id;
            this.text = text;
            statistics = new List<string>();
            lettersStatics = new Dictionary<char, int>();

            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            statistics.Add("Кол-во слов: " + Convert.ToString(words.Length));

            name = $"{words[0]} {words[1]} {words[2]}";

            string[] sentences = text.Split(new char[] { '.', '!', '?'});
            statistics.Add("Кол-во предложений: " + Convert.ToString(sentences.Length));

            string shortles = words[0];
            string longest = words[0];
            foreach (string word in words)
            {
                if (word.Length > longest.Length) longest = word;
                else if (word.Length < shortles.Length) shortles = word;
            }
            statistics.Add("Самое короткое слово: " + shortles);
            statistics.Add("Самое длинное слово: " + longest);

            int vowelCount = 0;
            int consonantCount = 0;

            string lowerText = text.ToLower();
            foreach(char letter in lowerText)
            {
                if ((letter >= 'а' && letter <= 'я') || letter == 'ё')
                {
                    if (lettersStatics.ContainsKey(letter)) lettersStatics[letter]++;
                    else lettersStatics.Add(letter, 1);

                    if (vowels.Contains(letter)) vowelCount++;
                    else consonantCount++;
                }
            }
            statistics.Add("Кол-во гласных: " + vowelCount);
            statistics.Add("Кол-во согласных: " + consonantCount);
        }

        public void PrintStatistics()
        {
            foreach(string stat in statistics)
            {
                Console.WriteLine(stat);
            }
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Статистика по буквам:");
            foreach (var letterStat in lettersStatics)
            {
                Console.WriteLine($"{letterStat.Key}: {letterStat.Value}");
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
                Console.WriteLine("2. Выбрать другой текст");
                Console.WriteLine("3. Статистика по текушему тексту");
                Console.WriteLine("0. Выход");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------");
                switch(choice)
                {
                    case 0: inMenu = false; break;
                    case 1: AddText(); break;
                    case 2: TextList(); break;
                    case 3: texts.Find(n => n.id == currentTextId).PrintStatistics(); break;
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
            Console.WriteLine($"Введите id текста, котрый хотите выбрать (от 1 до {gid - 1})");
            currentTextId = Convert.ToInt32(Console.ReadLine());
        }
    }
}
