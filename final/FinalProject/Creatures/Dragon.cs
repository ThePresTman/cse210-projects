namespace Creatures
{
    public class Dragon : Creature
    {
        public Dragon() : base("Dragon", 120, 25, 10) {}

        public override void SpecialAbility(Creature target)
        {
            int fireDamage = 20;
            target.TakeDamage(fireDamage);
            Console.WriteLine($"{Name} breathes FIRE on {target.Name} for {fireDamage}!");
        }
    }
}
