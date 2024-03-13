using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_RPG
{
    class Enemy : Entity
    {
        public static Enemy enemy1 = new Enemy("Vampire", 10, 10, new Stats(15, 15, 15), 100);
        public static Enemy enemy2 = new Enemy("Dark Spirit", 10, 10, new Stats(7, 7, 7), 10);
        public static Enemy enemy3 = new Enemy("Mummy", 10, 10, new Stats(5, 5, 5), 10);
        public static Enemy enemy4 = new Enemy("Skeleton", 0, 0, new Stats(4, 4, 4), 0);

        public int XPDroppedOnDefeat;

        public Enemy(string name, int hp, int mana, Stats stats, int XPDroppedOnDefeat) : base(name, hp, mana, stats)
        {
            this.XPDroppedOnDefeat = XPDroppedOnDefeat;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(targets.Count)];
        }
        public override void Attack(Entity target)
        {
            Console.WriteLine(this.name + " attacked " + target.name + "!");
        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());
            Attack(target);
        }

        
    }
}
