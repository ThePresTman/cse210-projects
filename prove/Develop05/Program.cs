using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Eternal Quest ===");
            Console.WriteLine($"Score: {score}");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": running = false; break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("\nChoose Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int pts = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            goals.Add(new SimpleGoal(name, desc, pts));
        }
        else if (type == "2")
        {
            goals.Add(new EternalGoal(name, desc, pts));
        }
        else if (type == "3")
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());

            goals.Add(new ChecklistGoal(name, desc, pts, target, bonus));
        }

        Console.WriteLine("Goal created!");
    }

    static void ListGoals()
    {
        Console.WriteLine("\n=== Goals ===");
        int index = 1;
        foreach (var g in goals)
        {
            Console.WriteLine($"{index}. {g.GetStatus()}");
            index++;
        }
    }

    static void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal did you complete? #: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int earned = goals[index].RecordEvent();
        score += earned;

        Console.WriteLine($"You earned {earned} points!");
    }

    static void SaveGoals()
    {
        Console.Write("File name: ");
        string file = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(file))
        {
            sw.WriteLine(score);
            foreach (var g in goals)
                sw.WriteLine(g.Serialize());
        }

        Console.WriteLine("Saved!");
    }

    static void LoadGoals()
    {
        Console.Write("File name: ");
        string file = Console.ReadLine();

        string[] lines = File.ReadAllLines(file);
        score = int.Parse(lines[0]);
        goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] p = lines[i].Split('|');

            switch (p[0])
            {
                case "SimpleGoal":
                    goals.Add(new SimpleGoal(p[1], p[2], int.Parse(p[3]), bool.Parse(p[4])));
                    break;

                case "EternalGoal":
                    goals.Add(new EternalGoal(p[1], p[2], int.Parse(p[3])));
                    break;

                case "ChecklistGoal":
                    goals.Add(new ChecklistGoal(
                        p[1], p[2],
                        int.Parse(p[3]),
                        int.Parse(p[4]),
                        int.Parse(p[5]),
                        int.Parse(p[6])
                    ));
                    break;
            }
        }

        Console.WriteLine("Loaded!");
    }
}
