using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Task1
{
    class Program
    {
        static readonly string Path1 = @"C:\Users\Sergii\Desktop\Collection\Task1.txt";
        static void Main(string[] args)
        {
            var text = ReadFile(Path1);
            var listTime = TimeList(text);
            var linkedListTime = TimeLinkedList(text);

            Console.WriteLine(" List Time -> {0}, LinkedList Time -> {1}.", listTime, linkedListTime);

            Console.ReadKey();
        }

        static string[] ReadFile(string path)
        {          
            string[] text = File.ReadAllLines(path);
            return text;
        }

        static long TimeList(string[] text)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var list = new List<string>();

            foreach (var item in text)
            {
                list.Add(item);
            }

            stopWatch.Stop();

            return stopWatch.ElapsedMilliseconds;
        }

        static long TimeLinkedList(string[] text)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var list = new LinkedList<string>();

            foreach (var item in text)
            {
                list.AddFirst(item);
            }

            stopWatch.Stop();

            return stopWatch.ElapsedMilliseconds;
        }

    }
}
