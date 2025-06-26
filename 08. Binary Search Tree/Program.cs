namespace _08._Binary_Search_Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // При двоичното търсещо дърво всички елементи със стойност по-малка от корена
            // отиват в лявото поддърво, а всички елементи със стойност по-голяма от корена
            // отиват в дясното поддърво.
            // Това позволява бързо търсене, вмъкване и изтриване на елементи.
            BinarySearchTree tree = new BinarySearchTree();
            int[] values = { 5, 3, 8, 1, 4, 7, 9 };
            foreach (var val in values)
                tree.Insert(val);

            Console.WriteLine("In-Order Traversal:");
            tree.InOrderTraversal(); // Output: 1 3 4 5 7 8 9
            Console.WriteLine();

            Console.WriteLine("Tree contains 4? " + tree.Contains(4)); // true
            Console.WriteLine("Height of tree: " + tree.GetHeight());
            Console.WriteLine("Is balanced? " + tree.IsBalanced());

            Console.WriteLine("\nDeleting 3...");
            tree.Delete(3);

            Console.WriteLine("In-Order Traversal after deletion:");
            tree.InOrderTraversal(); // 1 4 5 7 8 9
            Console.WriteLine();
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinarySearchTree
    {
        public Node? Root { get; private set; }

        // Вмъкване
        public void Insert(int value)
        {
            Root = InsertRecursive(Root, value);
        }

        private Node InsertRecursive(Node? node, int value)
        {
            if (node == null)
                return new Node(value);

            if (value < node.Value)
                node.Left = InsertRecursive(node.Left, value);
            else if (value > node.Value)
                node.Right = InsertRecursive(node.Right, value);

            return node;
        }

        // Търсене
        public bool Contains(int value)
        {
            return ContainsRecursive(Root, value);
        }

        private bool ContainsRecursive(Node? node, int value)
        {
            if (node == null)
                return false;

            if (value == node.Value)
                return true;
            else if (value < node.Value)
                return ContainsRecursive(node.Left, value);
            else
                return ContainsRecursive(node.Right, value);
        }

        // Обхождания
        public void InOrderTraversal() => InOrder(Root);
        private void InOrder(Node? node)
        {
            if (node == null) return;
            InOrder(node.Left);
            Console.Write($"{node.Value} ");
            InOrder(node.Right);
        }

        public void PreOrderTraversal() => PreOrder(Root);
        private void PreOrder(Node? node)
        {
            if (node == null) return;
            Console.Write($"{node.Value} ");
            PreOrder(node.Left);
            PreOrder(node.Right);
        }

        public void PostOrderTraversal() => PostOrder(Root);
        private void PostOrder(Node? node)
        {
            if (node == null) return;
            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.Write($"{node.Value} ");
        }

        // Височина
        public int GetHeight()
        {
            return GetHeightRecursive(Root);
        }

        private int GetHeightRecursive(Node? node)
        {
            if (node == null) return -1;
            int left = GetHeightRecursive(node.Left);
            int right = GetHeightRecursive(node.Right);
            return 1 + Math.Max(left, right);
        }

        // Проверка за балансираност
        public bool IsBalanced() => IsBalancedRecursive(Root);

        private bool IsBalancedRecursive(Node? node)
        {
            if (node == null) return true;

            int left = GetHeightRecursive(node.Left);
            int right = GetHeightRecursive(node.Right);

            if (Math.Abs(left - right) > 1)
                return false;

            return IsBalancedRecursive(node.Left) && IsBalancedRecursive(node.Right);
        }

        // Изтриване
        public void Delete(int value)
        {
            Root = DeleteRecursive(Root, value);
        }

        private Node? DeleteRecursive(Node? node, int value)
        {
            if (node == null) return null;

            if (value < node.Value)
                node.Left = DeleteRecursive(node.Left, value);
            else if (value > node.Value)
                node.Right = DeleteRecursive(node.Right, value);
            else
            {
                // Без деца
                if (node.Left == null && node.Right == null) return null;

                // С едно дете
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                // С две деца – намираме най-малкия от дясното поддърво
                Node min = FindMin(node.Right);
                node.Value = min.Value;
                node.Right = DeleteRecursive(node.Right, min.Value);
            }

            return node;
        }

        private Node FindMin(Node node)
        {
            while (node.Left != null)
                node = node.Left;
            return node;
        }
    }
}
