using System;
using System.Collections.Generic;
using System.Linq;



namespace Console_RPG
{

    class Player : Entity
    {
        public static Player player1 = new Player("PJ", 100, 100, new Stats(10, 10, 10), 1);

        public static List<Item> Inventory = new List<Item>() { Item.potionI, Item.potionII };
        public static int CoinCount = 0;

        public int Level;

        public Player(string name, int hp, int mana, Stats stats, int Level) : base(name, hp, mana, stats)
        {
            this.Level = Level;
        }

        public override Entity ChooseTarget(List<Entity> choices)
        {
            Console.WriteLine("Type in the number of the enemy you want to target");

            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name}");


            }
         
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];

        }

        public Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("Type in the number of an item you would like to use");

            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name}");


            }
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];

        }

        public override void Attack(Entity target)
        {
         
            Console.WriteLine(this.name + " attacked " + target.name + " ! ");
        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Console.WriteLine("What would you like to do");
            Console.WriteLine("ATTACK | ITEM");
            string choice = Console.ReadLine();

            if (choice == "ATTACK")
            {
                Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                Attack(target);
            }

            else if (choice == "ITEM")
            {
                Item item = ChooseItem(Inventory);
                Entity target = ChooseTarget(players.Cast<Entity>().ToList());

                item.Use(this, target);
                Inventory.Remove(item);

            }



        }

    }




}
