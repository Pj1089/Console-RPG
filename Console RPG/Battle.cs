using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Console_RPG
{
    class Battle : LocationFeature
    {
        public List<Enemy> enemies;


        public Battle(List<Enemy> enemies) : base(false)
        {
            this.enemies = enemies;

        }
        public override void Resolve(List<Player> players)
        {
            while (true)
            {
                foreach (var player in players)
                {
                    if (player.currentHP > 0)
                    {
                        Console.WriteLine("It's " + player.name + "'s turn.");
                        player.DoTurn(players, enemies);
                    }

                }


                foreach (var enemies in enemies)
                {
                    if (enemies.currentHP > 0)
                    {
                        Console.WriteLine("It's " + enemies.name + "'s turn.");
                        enemies.DoTurn(players, this.enemies);
                    }
                    else
                    {
                        Console.WriteLine("Enemy can no longer continue fighting");
                    }
                }
                if (players.TrueForAll(player => player.currentHP <= 0))
                {
                    Console.WriteLine("");
                    break;
                }

                if (enemies.TrueForAll(enemy => enemy.currentHP <= 0))
                {
                    Console.WriteLine("");
                   
                    break;
                }
            }
        }
    }
}