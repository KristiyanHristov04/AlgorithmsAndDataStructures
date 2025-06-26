namespace _09._Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdjacencyMatrix();
            //EdgeListMatrix();
        }

        // Ориентиран претеглен граф имплементация чрез списък на ребрата
        public static void EdgeListMatrix()
        {
            List<Edge> edges = new List<Edge>();
            edges.Add(new Edge("A", "B", 5));
            edges.Add(new Edge("A", "C", 3));
            edges.Add(new Edge("B", "D", 2));
            edges.Add(new Edge("C", "D", 4));

            foreach (Edge e in edges)
            {
                Console.WriteLine($"From {e.From} to {e.To} with weight: {e.Weight}");
            }
        }

        class Edge
        {
            public string From { get; set; }
            public string To { get; set; }
            public int Weight { get; set; }

            public Edge(string from, string to, int weight)
            {
                this.From = from;
                this.To = to;
                this.Weight = weight;
            }
        }

        // Ориентиран претеглен граф имплементация чрез матрица на съседство
        public static void AdjacencyMatrix()
        {
            //   A B C D
            // A 0 5 3 0
            // B 0 0 0 2
            // C 0 0 0 4
            // D 0 0 0 0
            string[] nodes = { "A", "B", "C", "D" };
            int[,] matrix = new int[4, 4];

            matrix[0, 1] = 5; // A -> B
            matrix[0, 2] = 3; // A -> C
            matrix[1, 3] = 2; // B -> D
            matrix[2, 3] = 4; // C -> D

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            //Принтиране на кой връх към кого сочи и с каква цена на реброто
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        Console.Write($"{nodes[i]} is connected to: {nodes[j]} (weight: {matrix[i, j]})");
                        Console.WriteLine();
                    }
                }

            }

            bool[] visited = new bool[nodes.Length];
            DFS(matrix, nodes, 0, visited);
            BFS(matrix, nodes, 0);
        }

        //Recursively using the call stack
        public static void DFS(int[,] matrix, string[] nodes, int current, bool[] visited)
        {
            Console.WriteLine($"Visited: {nodes[current]}");
            visited[current] = true;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[current, i] != 0 && !visited[i])
                {
                    DFS(matrix, nodes, i, visited);
                }
            }
        }

        //Using queue
        public static void BFS(int[,] matrix, string[] nodes, int start)
        {
            bool[] visited = new bool[nodes.Length];
            Queue<int> queue = new Queue<int>();

            visited[start] = true;
            queue.Enqueue(start);

            Console.WriteLine("BFS Traversal:");

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                Console.Write($"{nodes[current]} ");

                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (matrix[current, i] != 0 && !visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
