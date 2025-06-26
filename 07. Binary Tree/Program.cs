namespace _07._Binary_Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(5);
            root.Left = new Node(3);
            root.Right = new Node(8);
            root.Left.Left = new Node(1);
            root.Left.Right = new Node(4);

            Console.WriteLine("Inorder traversal");
            InOrderTraversal(root);

            Console.WriteLine("Preorder traversal");
            PreOrderTraversal(root);

            Console.WriteLine("Postorder traversal");
            PostOrderTraversal(root);

            Console.WriteLine(FindNodeValue(root, 4));
        }

        // ЛКД -> ЛЯВО-КОРЕН-ДЯСНО
        static void InOrderTraversal(Node? node)
        {
            //Base case
            if (node == null)
            {
                return;
            }
            
            InOrderTraversal(node.Left);
            Console.WriteLine(node.Value);
            InOrderTraversal(node.Right);
        }

        // КЛД -> КОРЕН-ЛЯВО-ДЯСНО 
        static void PreOrderTraversal(Node? node)
        {
            //Base case
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.Value);
            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);
        }

        // ЛДК -> ЛЯВО-ДЯСНО-КОРЕН
        static void PostOrderTraversal(Node? node)
        {
            //Base case
            if (node == null)
            {
                return;
            }

            PostOrderTraversal(node.Left);
            PostOrderTraversal(node.Right);
            Console.WriteLine(node.Value);
        }

        // Търсене на връх в двоично дърво. Функцията реално обхожда дървото с КЛД подхода.
        static bool FindNodeValue(Node? node, int target)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Value == target)
            {
                return true;
            }

            return FindNodeValue(node.Left, target) || FindNodeValue(node.Right, target);
        }
    }

    class Node
    {
        public int Value { get; set; }

        public Node? Left { get; set; }

        public Node? Right { get; set; }

        public Node(int value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null!;
        }
    }
}
