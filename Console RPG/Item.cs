using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {

        public static HealthPotionItem potionI = new HealthPotionItem("Potion I", "", 5, 5, 5, 15);
        public static HealthPotionItem potionII = new HealthPotionItem("Potion II", "", 10, 5, 25, 30);
        public static HealthPotionItem potionIII = new HealthPotionItem("Potion III", "", 15, 5, 50, 45);
        public static HealthPotionItem potionIV = new HealthPotionItem("Potion IV", "", 20, 5, 75, 60);

        public static ManaItem manaI = new ManaItem("Mana I", "", 10, 10, 25, 15);
        public static ManaItem manaII = new ManaItem("Mana II", "", 10, 8, 50, 30);
        public static ManaItem manaIII = new ManaItem("Mana III", "", 10, 6, 75, 45);
        public static ManaItem manaIV = new ManaItem("Mana IV", "", 15, 4, 100, 60);


        public string name;
        public string description;
        public int shopPrice;
        public int sellprice;
        public int maxAmount;


        public Item(string name, string description, int shopPrice, int sellPrice, int maxAmount)
        {
            this.name = name;
            this.description = description;
            this.shopPrice = shopPrice;
            this.sellprice = sellPrice;
            this.maxAmount = maxAmount;

        }



        public abstract void Use(Entity user, Entity target);

    }


    class HealthPotionItem : Item
    {
        public int healAmount;

        public HealthPotionItem(string name, string description, int shopPrice, int sellPrice, int maxAmount, int healAmount) : base(name, description, shopPrice, sellPrice, maxAmount)
        {
            this.healAmount = healAmount;

        }

        public override void Use(Entity user, Entity target)
        {
            user.currentHP += this.healAmount;

        }

    }

    class ExplosiveRepeater : Item
    {
        public int damage;
        public int ammo;


        public ExplosiveRepeater(string name, string description, int shopPrice, int sellPrice, int maxAmount, int damage, int ammo) : base(name, description, shopPrice, sellPrice, maxAmount)
        {
            this.damage = damage;
            this.ammo = ammo;

        }

        public override void Use(Entity user, Entity target)
        {
            if (ammo == 0)
                return;

            target.currentHP -= this.damage;
            --ammo;

        }

    }


}