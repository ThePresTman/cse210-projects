namespace Creatures
{
    public class Wizard : Creature
    {
        public Wizard() : base("Wizard", 80, 20, 4) { }

        public override void SpecialAbility(Creature target)
        {
            Console.WriteLine($"{Name} casts a lightning bolt!");
            target.TakeDamage(25);
        }
    }
}
