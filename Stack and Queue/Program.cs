namespace _05._Stack_and_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QueueMethod();
        }

        public static void StackMethod()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Pop();
            stack.Contains(25);
            int[] stackAsArray = stack.ToArray();
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Count);

        }

        public static void QueueMethod()
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Dequeue();
            queue.Contains(25);
            int[] queueAsArray = queue.ToArray();
            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Count);
        }
    }
}
