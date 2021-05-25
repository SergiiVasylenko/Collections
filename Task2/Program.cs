using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task2
{
    class Program
    {
        static readonly string Path2 = @"C:\Users\Sergii\Desktop\Collection\Task2.txt";
        static void Main(string[] args)
        {
            var text = ReadFile(Path2);
            var list = GetWords(text);

            var topTenRepeatWords = list.OrderByDescending(x => x.Value).Take(10);

            foreach (var item in topTenRepeatWords)
            {
                Console.WriteLine("Word -> {0}, Count -> {1}", item.Key, item.Value);
            }

            Console.ReadKey();
        }

        static string[] ReadFile(string path)
        {
            string text = File.ReadAllText(path);
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            string[] mystring = noPunctuationText.Split(' ');
            return mystring;
        }

        static List<WordObject> GetWords(string[] text)
        {
            var list = new List<WordObject>();
            WordObject item;
            foreach (var word in text)
            {
                item = list.FirstOrDefault(x => x.Key == word);
                if (item != null)
                {
                    item.Value++; 
                }
                else
                {
                    list.Add(new WordObject { Key = word, Value = 1 });
                }
            }

            return list;
        }
    }

    class WordObject
    {
        public string Key { get; set; }
        public long Value { get; set; }
    }
}
