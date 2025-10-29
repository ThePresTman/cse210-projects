using System;

namespace Develop03
{
    class Program
    {
        static void Main()
        {
            ScriptureReference reference = new ScriptureReference("John", 3, 16);
            Scripture scripture = new Scripture(reference, "For God so loved the world that He gave His one and only Son, that whoever believes in Him shall not perish but have eternal life.");

            while (true)
            {
                Console.Clear();
                scripture.Display();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("All words are hidden. Well done!");
                    break;
                }

                Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "quit")
                    break;

                scripture.HideRandomWords();
            }
        }
    }
}
