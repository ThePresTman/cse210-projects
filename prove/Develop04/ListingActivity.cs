using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by listing as many items as possible."
    ) { }

    public void Run()
    {
        StartActivity();
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine("\n" + prompt);
        Console.WriteLine("Start listing items (press Enter after each, blank line to finish early):");

        int duration = GetDuration();
        DateTime start = DateTime.Now;
        int count = 0;

        while ((DateTime.Now - start).TotalSeconds < duration)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items.");
        EndActivity();
    }
}
