using System.Collections;

namespace _10._Hashtable____Dictionary__HashSet_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "Ivan");
            //dictionary.Add(1, "Ivan");
            dictionary.Add(2, "Martin");

            HashSet<string> hashset = new HashSet<string>();
            hashset.Add("Ivan");
            hashset.Add("Ivan");
            hashset.Add("Martin");
            Console.WriteLine(hashset.Count);

            Hashtable hashtable = new Hashtable();
            hashtable.Add("Ivan", "Ivan");
            hashtable.Add("Kiro", "Kiro");
            Console.WriteLine(hashtable.Count);
            Console.WriteLine(hashtable["Ivan"]!.GetHashCode());
            Console.WriteLine(hashtable["Kiro"]!.GetHashCode());

            int x = 50;
            Console.WriteLine(x.GetHashCode());
        }
    }
}
