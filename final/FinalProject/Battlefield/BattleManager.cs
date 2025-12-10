using Creatures;

namespace Battlefield
{
    public class BattleManager
    {
        private Creature _c1;
        private Creature _c2;
        private TurnHandler _turnHandler;

        public BattleManager(Creature c1, Creature c2)
        {
            _c1 = c1;
            _c2 = c2;
            _turnHandler = new TurnHandler();
        }

        public void StartBattle()
        {
            Console.WriteLine($"\nBattle Start: {_c1.Name} vs {_c2.Name}!");

            while (_c1.Health > 0 && _c2.Health > 0)
            {
                _turnHandler.TakeTurn(_c1, _c2);
                if (_c2.Health <= 0) break;

                _turnHandler.TakeTurn(_c2, _c1);
            }

            Creature winner = _c1.Health > 0 ? _c1 : _c2;
            Console.WriteLine($"\n🎉 Winner: {winner.Name}!");
        }
    }
}
