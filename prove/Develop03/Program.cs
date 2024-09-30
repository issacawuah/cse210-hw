 public class Program
{
    public static void Main(string[] args)
    {
        var reference = new Reference("John", 3, new List<int> { 16 });
        var scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son");

        while (true)
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit") break;

            scripture.HideRandomWords(1); // Hide one word at a time

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                scripture.Display();
                Console.WriteLine("All words are now hidden. Press Enter to exit.");
                Console.ReadLine();
                break;
            }
        }
    }
}
