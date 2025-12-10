namespace Battlefield
{
    public class DamageCalculator
    {
        public int CalculateDamage(int attack, int defense)
        {
            int damage = attack - defense;
            return damage < 0 ? 0 : damage;
        }
    }
}
