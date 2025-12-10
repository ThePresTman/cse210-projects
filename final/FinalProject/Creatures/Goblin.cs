namespace Creatures
{
    public class Goblin : Creature
    {
        public Goblin() : base("Goblin", 70, 15, 5) { }

        public override void SpecialAbility(Creature target)
        {
            Console.WriteLine($"{Name} steals 10 health!");
            this.Health += 10;
        }
    }
}
