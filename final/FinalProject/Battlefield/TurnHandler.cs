using Creatures;

namespace Battlefield
{
    public class TurnHandler
    {
        public void TakeTurn(Creature attacker, Creature defender)
        {
            // Clear console at start of each turn for cleaner display
            Console.Clear();

            Console.WriteLine($"=== {attacker.Name}'s Turn ===");
            Console.WriteLine($"{attacker.Name} HP: {attacker.Health}");
            Console.WriteLine($"{defender.Name} HP: {defender.Health}");
            Console.WriteLine();
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Basic Attack");
            Console.WriteLine("2. Special Ability");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                int damage = attacker.Attack() - defender.Defend();
                if (damage < 0) damage = 0;

                defender.TakeDamage(damage);
                Console.WriteLine($"\n{attacker.Name} hits {defender.Name} for {damage} damage!");
            }
            else
            {
                attacker.SpecialAbility(defender);
            }

            Console.WriteLine($"\nStatus after this turn:");
            Console.WriteLine($"{attacker.Name} HP: {attacker.Health}");
            Console.WriteLine($"{defender.Name} HP: {defender.Health}");

            // Pause briefly so the player can read the results
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
