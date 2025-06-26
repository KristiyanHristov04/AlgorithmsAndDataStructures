namespace _06._List_Structures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedListTaskExample02();
        }

        public static void LinkedListTaskExample02()
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            Queue<int> queue = new Queue<int>();

            for (int i = 100; i <= 999; i++)
            {
                int firstDigit = i / 100;
                int thirdDigit = i % 10;
                if (i % (firstDigit + thirdDigit) == 0)
                {
                    linkedList.AddLast(i);
                }
            }

            Console.Write("Enter a number that if can be divided on the number it will remove it: ");
            int number = Convert.ToInt32(Console.ReadLine());

            LinkedListNode<int>? current = linkedList.First;

            while (current != null)
            {
                LinkedListNode<int>? nextNode = current.Next;

                if (current.Value % number == 0)
                {
                    linkedList.Remove(current);
                    queue.Enqueue(current.Value);
                }

                current = nextNode;
            }

            Console.WriteLine("Final LinkedList");
            Console.WriteLine(String.Join(", ", linkedList));
            Console.WriteLine("Final Queue");
            Console.WriteLine(String.Join(", ", queue));
        }

        public static void LinkedListTaskExample()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            // Добавяне на 10 елемента в началото (ще се подредят в обратен ред: 10 до 1)
            for (int i = 1; i <= 10; i++)
            {
                linkedList.AddFirst(i);
            }

            Console.WriteLine("Initial LinkedList:");
            foreach (var node in linkedList)
            {
                Console.Write(node + " ");
            }

            Console.Write("\nDelete the nodes with value greater than: ");
            int x = Convert.ToInt32(Console.ReadLine());

            LinkedListNode<int>? current = linkedList.First;
            LinkedListNode<int>? lastXNode = null;

            // Обхождаме списъка и:
            // 1) трием стойности > x
            // 2) помним последния възел със стойност == x
            while (current != null)
            {
                LinkedListNode<int> next = current.Next;

                if (current.Value > x)
                {
                    linkedList.Remove(current);
                }
                else if (current.Value == x)
                {
                    lastXNode = current;
                }

                current = next;
            }

            // Добавяме 10 след последното срещане на x, ако е намерено
            if (lastXNode != null)
            {
                linkedList.AddAfter(lastXNode, 10);
            }

            Console.WriteLine("\nChanged LinkedList:");
            foreach (var node in linkedList)
            {
                Console.Write(node + " ");
            }
        }

        public static void ListMethod()
        {
            List<int> list = new List<int>();
            Console.WriteLine(list.Capacity);
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(40);
            list.Add(40);
            Console.WriteLine(list.Capacity);
            list.Remove(10);
            list.RemoveAt(0);
            list.Insert(0, 15);
            list.Clear();
            Console.WriteLine(list.Capacity);
            list.EnsureCapacity(100);
            Console.WriteLine(list.Capacity);
        }
    }
}
