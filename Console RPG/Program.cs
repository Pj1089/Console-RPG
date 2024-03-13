using System;
using System.Collections.Generic;
using System.Threading;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
         


            Location.Room.SetNearbyLocations(west: Location.WestHall, south: Location.Ballroom, east: Location.NorthHall);

            Location.WestHall.SetNearbyLocations(east: Location.Room, south: Location.Dungeon, west: Location.WanderingMerchantPost);

            Location.WanderingMerchantPost.SetNearbyLocations(east: Location.EastHall, south: Location.RoyalQuarters);

            Location.Outside.SetNearbyLocations(south: Location.NorthHall, west: Location.Dungeon);

            Location.RoyalQuarters.SetNearbyLocations(east: Location.Ballroom, north: Location.WanderingMerchantPost);

            Location.Dungeon.SetNearbyLocations(west: Location.RoyalQuarters, east: Location.Outside, north: Location.WestHall);

            Location.SouthHall.SetNearbyLocations(north: Location.RoyalQuarters);

            Location.NorthHall.SetNearbyLocations(west: Location.Room);

            Location.Ballroom.SetNearbyLocations(north: Location.Room, south: Location.WanderingMerchantPost);

            Location.EastHall.SetNearbyLocations(south: Location.Dungeon);

            Location.Room.Resolve(new List<Player>() { Player.player1 });

        }
    }
}