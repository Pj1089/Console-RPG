namespace Console_RPG
{
    // Structs are useful for storing simple plain data.
    struct Stats
    { 
        public int strength;
        public int defense;
        public int speed;

        public Stats(int strength, int defense, int speed)
        {
            this.strength = strength;
            this.defense = defense;
            this.speed = speed;
        }
    }
}
