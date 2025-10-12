using System;

public class Program
{
    public static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator generator = new PromptGenerator();
        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = generator.GetRandomPrompt();
                    Console.WriteLine($"\n{prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Console.Write("On a scale of 1–10, how was your mood today? ");
                    int mood;
                    while (!int.TryParse(Console.ReadLine(), out mood) || mood < 1 || mood > 10)
                    {
                        Console.Write("Please enter a valid number between 1 and 10: ");
                    }

                    Entry newEntry = new Entry
                    {
                        _date = DateTime.Now.ToShortDateString(),
                        _time = DateTime.Now.ToShortTimeString(),
                        _prompt = prompt,
                        _response = response,
                        _moodRating = mood
                    };

                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry added successfully!");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save (example: journal.txt): ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load (example: journal.txt): ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }
}