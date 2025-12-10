namespace Creatures
{
    public class Vampire : Creature
    {
        public Vampire() : base("Vampire", 90, 18, 6) { }

        public override void SpecialAbility(Creature target)
        {
            Console.WriteLine($"{Name} drains 15 health from {target.Name}!");
            target.TakeDamage(15);
            Health += 10;
        }
    }
}
