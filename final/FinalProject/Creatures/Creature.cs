namespace Creatures
{
    public abstract class Creature
    {
        private int _health;
        private int _attack;
        private int _defense;

        public string Name { get; protected set; }

        public int Health
        {
            get => _health;
            protected set => _health = value < 0 ? 0 : value;
        }

        public Creature(string name, int health, int attack, int defense)
        {
            Name = name;
            _health = health;
            _attack = attack;
            _defense = defense;
        }

        public virtual int Attack() => _attack;

        public int Defend() => _defense;

        public void TakeDamage(int amount)
        {
            Health -= amount;
        }

        public abstract void SpecialAbility(Creature target);
    }
}
