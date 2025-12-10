using System;
using Creatures;
using Battlefield;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Fantasy Creature Battle Simulator ===");

        // Choose creatures for both players
        Creature creature1 = ChooseCreature("Player 1");
        Creature creature2 = ChooseCreature("Player 2");

        // Start the battle
        BattleManager battle = new BattleManager(creature1, creature2);
        battle.StartBattle();

        Console.WriteLine("\nThanks for playing! Press any key to exit.");
        Console.ReadKey();
    }

    static Creature ChooseCreature(string player)
    {
        Console.WriteLine($"\n{player}, choose your creature:");
        Console.WriteLine("1. Dragon");
        Console.WriteLine("2. Goblin");
        Console.WriteLine("3. Wizard");
        Console.WriteLine("4. Troll");
        Console.WriteLine("5. Vampire");

        while (true)
        {
            Console.Write("Enter choice (1-5): ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    return new Dragon();
                case "2":
                    return new Goblin();
                case "3":
                    return new Wizard();
                case "4":
                    return new Troll();
                case "5":
                    return new Vampire();
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
