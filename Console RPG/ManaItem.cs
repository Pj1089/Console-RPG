namespace Console_RPG
{
    class ManaItem: Item
    {
        public int manaUp;

        public ManaItem(string name, string description, int shopPrice, int sellprice, int maxAmount, int manaUp) : base(name, description, shopPrice, sellprice, maxAmount)
        {
            this.manaUp = manaUp;



        }

        public override void Use(Entity user, Entity target)
        {
            user.currentMana += this.manaUp;

        }


    }

}