using System.Diagnostics;

namespace _03._Search_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine(BinarySearch());

            stopwatch.Stop();
            Console.WriteLine("Milliseconds: " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Seconds: " + stopwatch.ElapsedMilliseconds / 1000);
        }

        // Requires sorted array
        public static int BinarySearch()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int target = 6;

            int left = 0;
            int right = numbers.Length - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                if (numbers[middle] == target)
                {
                    return 1;
                }
                else if (numbers[middle] > target)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return 0;
        }

        //Requires sorted array
        public static int JumpSearch()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int target = 50;

            int step = (int)Math.Sqrt(numbers.Length);

            for (int i = step - 1; i < numbers.Length; i += step)
            {
                if (numbers[i] >= target)
                {
                    for (int j = i - step + 1; j <= i; j++)
                    {
                        if (numbers[j] == target)
                        {
                            return 1;
                        }
                    }
                }

                if (i + step >= numbers.Length && numbers[i + 1] == target)
                {
                    return 1;
                }
            }

            return 0;
        }

        public static int LinearSearch()
        {
            int[] numbers = new int[] { 23, 33, 38, 22, 18, 43, 47, 24, 44, 14, 40 };

            int target = 244;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == target)
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
