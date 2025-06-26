namespace _00._Exercise_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task03();
        }

        public static void Task01()
        {
            Random random = new Random();
            int[] array = Enumerable.Range(1, 30).ToArray();

            Console.WriteLine(String.Join(", ", array));

            List<int> evenNumbers = new List<int>();
            Stack<int> oddNumbers = new Stack<int>();

            foreach (int number in array)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
                else
                {
                    oddNumbers.Push(number);
                }
            }

            double oddNumbersAvgSum = oddNumbers.Average();
            Console.WriteLine($"Average sum of odd numbers: {oddNumbersAvgSum}");

            Console.WriteLine("Even numbers: " + String.Join(", ", evenNumbers.Where(n => n > oddNumbersAvgSum)));
        }

        public static void Task02()
        {
            LinkedList<int> list = new LinkedList<int>();
            Random random = new Random();

            // Генерираме 10 положителни числа между 1 и 100
            while (list.Count < 10)
            {
                int num = random.Next(1, 101);
                list.AddLast(num);
            }

            Console.WriteLine("Initial LinkedList:");
            Console.WriteLine(string.Join(", ", list));

            LinkedListNode<int>? current = list.First;

            while (current != null)
            {
                LinkedListNode<int>? next = current.Next;
                bool shouldRemove = false;

                LinkedListNode<int>? checker = list.First;
                while (checker != null)
                {
                    if (checker != current && current.Value % checker.Value == 0)
                    {
                        shouldRemove = true;
                        break;
                    }
                    checker = checker.Next;
                }

                if (shouldRemove)
                {
                    list.Remove(current);
                }

                current = next;
            }

            Console.WriteLine("Final LinkedList:");
            Console.WriteLine(string.Join(", ", list));
        }

        public static void Task03()
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            Random random = new Random();
            Queue<int> queue = new Queue<int>();

            for (int i = 1; i <= 10; i++)
            {
                linkedList.AddLast(random.Next(1, 101));
            }

            Console.WriteLine(string.Join(", ", linkedList));

            Console.Write("x = ");
            int x = Convert.ToInt32(Console.ReadLine());
            int y;
            while (true)
            {
                Console.Write("y = ");
                y = Convert.ToInt32(Console.ReadLine());

                if (y <= x)
                {
                    Console.WriteLine("y should be greater than x!");
                }
                else
                {
                    break;
                }
            }
            

            LinkedListNode<int>? current = linkedList.First;

            while (current != null)
            {
                LinkedListNode<int>? next = current.Next;

                if (current.Value > x && current.Value < y)
                {
                    linkedList.Remove(current);
                }
                else
                {
                    if (current.Value % x == 0 || current.Value % y == 0)
                    {
                        queue.Enqueue(current.Value);
                    }
                }

                current = next;
            }

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
