using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Location
    {
        public static Location Room = new Location("your room", "A large dark room ridden with spiders and webs only illuminated by a single candlelight. Use this light to make your way through the dark castle.");

        public static Location SouthHall = new Location("the south Hall", "A long stony hallway potentially filled with monsters. This castle is filled with th- WATCH OUT!", new Battle(new List<Enemy>() { Enemy.enemy1 }));

        public static Location Dungeon = new Location("the dungeon", "A spaceous and dark room filled with skeletons of the last people who've inhabited this place before it was overridden by monsters. You will most likely find monsters here.");

        public static Location Outside = new Location("Exit", "The door outside is blocked by a barrier and monsters. How will you escape this castle???");

        public static Location WestHall = new Location("the west Hall", "This happened to be where the great massacre occured where the last humans to inhabit the castle where killed by monsters.");

        public static Location RoyalQuarters = new Location("the royal Quarters", "This is the kings room. His bed and the floor are covered in blood, for he and his wife were murdered in their sleep by the monsters.");

        public static Location Ballroom = new Location("the ballroom", "Where the royal balls were held. It's unnerving knowing that this used to be a place of celebration, and now, nearly 5 years later it is dark, abandoned, and hazardous. Look out!", new Battle(new List<Enemy>() { Enemy.enemy2 }));

        public static Location EastHall = new Location("the east hall", "You've made your way to the East Hall. look out fo- RUN!", new Battle(new List<Enemy> () {  Enemy.enemy4}));

        public static Location NorthHall = new Location("the north hall", "This is the North Hall. Dark, foggy, and abandoned just like the other halls. It's ironic really. These halls are so big, meant to fit hundreds yet now you are the only one here to fill them.");

        public static Location WanderingMerchantPost = new Location("the Wandering Merchant's Post", "Hmm what is this place? It looks like a huge castle! I'm just a wandering trader trying to sell my goods. I won't be here for lon- AHHH MONSTER! Quickly make your transaction so I can close up shop!", new Shop("Wandering Trader","Trading Post", new List<Item> {Item.potionI, Item.potionII, Item.potionIII, Item.potionIII}));
        
        public string name;
        public string description;
        public LocationFeature interaction;

        public Location north, east, south, west;

        public Location(string name, string description, LocationFeature interaction = null)
        {
            this.name = name;
            this.description = description;
            this.interaction = interaction;
        }

        public void SetNearbyLocations(Location north = null, Location east = null, Location south = null, Location west = null)
        {
            this.north = north;
            this.east = east;
            this.south = south;
            this.west = west;

            if (!(north is null))
                north.south = this;

            if (!(east is null))
                east.west = this;

            if (!(south is null))
                south.north = this;

            if (!(west is null))
                west.east = this;

        }

        public void Resolve(List<Player> players)
        {
            Console.WriteLine("You find yourself in " + this.name + ".");
            Console.WriteLine(this.description);

            interaction?.Resolve(players);

            if (!(north is null))
                Console.WriteLine("North: " + this.north.name);


            if (!(east is null))
                Console.WriteLine("East: " + this.east.name);



            if (!(south is null))
                Console.WriteLine("South: " + this.south.name);



            if (!(west is null))
                Console.WriteLine("West: " + this.west.name);



            string direction = Console.ReadLine();
            Location nextLocation = null;


            if (direction == "North")
                nextLocation = this.north;

            if (direction == "East")
                nextLocation = this.east;

            if (direction == "South")
                nextLocation = this.south;

            if (direction == "West")
                nextLocation = this.west;


            nextLocation.Resolve(players);

        }

    }

}