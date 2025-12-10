namespace Creatures
{
    public class Troll : Creature
    {
        public Troll() : base("Troll", 150, 18, 15) { }

        public override void SpecialAbility(Creature target)
        {
            Console.WriteLine($"{Name} regenerates 20 health!");
            Health += 20;
        }
    }
}
