using System;
using System.Diagnostics;

namespace _01._Introduction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            AccessingArrayIndex();
            PrintStringLetters();
            FindMinElement();
            FindProduct();

            stopwatch.Stop();
            Console.WriteLine("Milliseconds: " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Seconds: " + stopwatch.ElapsedMilliseconds / 1000);
        }

        // O(1) - Constant Time Complexity
        public static void AccessingArrayIndex()
        {
            Random randomNumber = new Random();
            int[] array = Enumerable
                .Repeat(0, 100_001)
                .Select(i => randomNumber.Next(0, 2))
                .ToArray();

            Console.WriteLine(array[100_000]);
        }

        // O(n) - Linear Time Complexity
        public static void PrintStringLetters()
        {
            string word = "Hello World";
            for (int i = 0; i < word.Length; i++)
            {
                Console.WriteLine(word[i]);
            }
        }

        // O(n) - Linear Time Complexity
        public static void FindMinElement()
        {
            int[] numbers = new int[] { 10, 5, 25, 4, 50, 6, 1, -10, -1 };
            int minNumber = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < minNumber)
                {
                    minNumber = numbers[i];
                }
            }

            Console.WriteLine("Min number is: " + minNumber);
        }

        // O(n^2) - Quadratic Time Complexity
        public static void FindProduct()
        {
            int n = 25;
            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sum++;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
