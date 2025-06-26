using System.Diagnostics;

namespace _02._Sorting_Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            InsertionSort();

            stopwatch.Stop();
            Console.WriteLine("Milliseconds: " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Seconds: " + stopwatch.ElapsedMilliseconds / 1000);
        }

        public static void BubbleSortDoWhile()
        {
            int[] numbers = new int[] { 1, 15, 4, 60, 2, 11, 5 };
            bool hasSwapped = false;
            do
            {
                hasSwapped = false;
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;
                        hasSwapped = true;
                    }
                }
            } while (hasSwapped);
            Console.WriteLine(String.Join(", ", numbers));
        }

        public static void BubbleSortFor()
        {
            int[] numbers = new int[] { 1, 15, 4, 60, 2, 11, 5 };

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        public static void SelectionSort()
        {
            int[] numbers = new int[] { 1, 10, -1, 5, 2, 5, 123 };

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int minElementIndex = i;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[minElementIndex])
                    {
                        minElementIndex = j;
                    }
                }

                if (minElementIndex != i)
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[minElementIndex];
                    numbers[minElementIndex] = temp;
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        public static void MyTryForInsertionSort()
        {
            int[] numbers = new int[] { 23, 33, 38, 22, 18, 43, 47, 24, 44, 14, 40 };

            for (int i = 1; i < numbers.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (numbers[i] < numbers[j])
                    {
                        int[] newArray = new int[numbers.Length];
                        bool isAbove = false;
                        for (int k = 0; k < numbers.Length; k++)
                        {
                            if (k == j)
                            {
                                newArray[k] = numbers[i];
                            }
                            else
                            {
                                int index = k < j ? k : k - 1;
                                if (index == i)
                                {
                                    index = k;
                                    isAbove = true;
                                }

                                newArray[isAbove ? index : k] = numbers[index];

                                if (index == i + 1)
                                {
                                    k++;
                                }

                                if (k + 1 == numbers.Length && isAbove)
                                {
                                    newArray[index + 1] = numbers[index + 1];
                                }
                            }
                        }

                        numbers = newArray;
                    }
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        public static void InsertionSort()
        {
            int[] numbers = new int[] { 23, 33, 38, 22, 18, 43, 47, 24, 44, 14, 40 };

            for (int i = 1; i < numbers.Length; i++)
            {
                int current = numbers[i];
                int j = i - 1;

                // Shift elements to the right to make room
                while (j >= 0 && numbers[j] > current)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }

                numbers[j + 1] = current;
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
