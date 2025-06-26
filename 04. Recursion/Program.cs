using System.Collections.Concurrent;
using System.Diagnostics;

namespace _04._Recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            MergeSortAlgorithm();

            stopwatch.Stop();
            Console.WriteLine("Milliseconds: " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Seconds: " + stopwatch.ElapsedMilliseconds / 1000);
        }

        //Recursive algorithm - divide and conquer
        public static void MergeSortAlgorithm()
        {
            int[] array = { 2, 1, 3, 5, 4 };
            MergeSort(array);

            Console.WriteLine("Sorted array: " + string.Join(", ", array));
        }

        public static void MergeSort(int[] array)
        {
            int length = array.Length;
            if (length <= 1)
            {
                return;
            }

            int middle = length / 2;
            int[] leftArray = new int[middle];
            int[] rightArray = new int[length - middle];

            int i = 0;
            int j = 0;

            for (; i < length; i++)
            {
                if (i < middle)
                {
                    leftArray[i] = array[i];
                }
                else
                {
                    rightArray[j] = array[i];
                    j++;
                }
            }
            MergeSort(leftArray);
            MergeSort(rightArray);
            Merge(leftArray, rightArray, array);
        }

        public static void Merge(int[] leftArray, int[] rightArray, int[] array)
        {

            int leftSize = array.Length / 2;
            int rightSize = array.Length - leftSize;
            int i = 0;
            int l = 0;
            int r = 0;

            while (l < leftSize && r < rightSize)
            {
                if (leftArray[l] < rightArray[r])
                {
                    array[i] = leftArray[l];
                    i++;
                    l++;
                }
                else
                {
                    array[i] = rightArray[r];
                    i++;
                    r++;
                }
            }
            while (l < leftSize)
            {
                array[i] = leftArray[l];
                i++;
                l++;
            }
            while (r < rightSize)
            {
                array[i] = rightArray[r];
                i++;
                r++;
            }
        }

        //Recursive algorithm - divide and conquer
        public static void QuickSortAlgorithm()
        {
            int[] array = { 2, 1, 3, 5, 4 };
            int startIndex = 0;
            int endIndex = array.Length - 1;

            QuickSort(array, startIndex, endIndex);

            Console.WriteLine("Sorted array: " + string.Join(", ", array));
        }

        public static void QuickSort(int[] array, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int middleIndex = (startIndex + endIndex) / 2;
                int pivot = array[middleIndex];
                int index = Partition(array, startIndex, endIndex, pivot);
                QuickSort(array, startIndex, index - 1);
                QuickSort(array, index, endIndex);
            }
        }

        public static int Partition(int[] array, int startIndex, int endIndex, int pivot)
        {
            while (startIndex <= endIndex)
            {
                while (array[startIndex] < pivot)
                {
                    startIndex++;
                }

                while (array[endIndex] > pivot)
                {
                    endIndex--;
                }

                if (startIndex <= endIndex)
                {
                    int temp = array[startIndex];
                    array[startIndex] = array[endIndex];
                    array[endIndex] = temp;
                    startIndex++;
                    endIndex--;
                }
            }

            return startIndex;
        }

        public static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        public static int Fibonacci(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public static int Euclid(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }

            return Euclid(b, a % b);
        }
    }
}
