using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Shop : LocationFeature
    {
        public string ownerName;
        public string shopName;
        public List<Item> items;

        public Shop(string ownerName, string shopName, List<Item> items) : base(false)
        {
            this.ownerName = ownerName;
            this.shopName = shopName;
            this.items = items;


        }


        public override void Resolve(List<Player> players)
        {
            Console.WriteLine($"Welcome to {ownerName}'s shop");

            while (true)
            {
                Console.WriteLine("What would you want to do");
                Console.WriteLine("Buy | Sell | Talk | Leave");
                string userInput = Console.ReadLine();
                if (userInput == "Buy")
                {

                    Item item = ChooseItem(this.items);
                    Player.CoinCount -= item.shopPrice;
                    Player.Inventory.Add(item);

                    Console.WriteLine($"You bought a {item.name}!");

                }
                else if (userInput == "Sell")
                {
                    Item item = ChooseItem(Player.Inventory);
                    Player.CoinCount += item.shopPrice;
                    Player.Inventory.Remove(item);

                    Console.WriteLine($"You sold a {item.name}!");
                }

                else if (userInput == "Talk")
                {
                    Console.WriteLine("What would you like from the shop today?");


                }

                else if (userInput == "Leave")
                {

                    break;

                }

            }

            Console.WriteLine("Have a Good rest of your day");

        }

        public Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("Type in the number of an Item you want to buy");

            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name} {choices[i].name} (${choices[i].shopPrice}");


            }
            //Let the user pick a choice
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];

        }


    }


}