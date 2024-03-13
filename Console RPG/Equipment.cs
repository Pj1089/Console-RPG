using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
 abstract class Equipment : Item
    {
        public float durability;
        public float weight;
        public float rarity;
        public bool isEquipped;

        protected Equipment(string name, string description, int shopPrice, int sellPrice, int maxAmount, float durability, float weight, float rarity) : base(name, description, shopPrice, sellPrice, maxAmount)
        {
            this.durability = durability;
            this.weight = weight;
            this.rarity = rarity;
            this.isEquipped = false;
        }
    }

    class Armor : Equipment
    {
        public int defense;

        public Armor(string name, string description, int shopPrice, int sellPrice, int maxAmount, float durability, float weight, float rarity, int defense) : base(name, description, shopPrice, sellPrice, maxAmount, durability, weight, rarity)
        {
            this.defense = defense;
        }

        public override void Use(Entity user, Entity target)
        {
            this.isEquipped = !this.isEquipped;

           if (this.isEquipped)
            {
                target.stats.defense += this.defense;
            }
           else
            {
                target.stats.defense -= this.defense;
            }
        }
    }
}
