using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    // Classes are useful for storing complex objects.
    abstract class Entity
    {
        public string name;

        public int currentHP, maxHP;
        public int currentMana, maxMana;

        // This is called composition. Composition is AWESOME!
        public Stats stats;
        public Entity(string name, int hp, int mana, Stats stats)
        {
            this.name = name;
            this.currentHP = hp;
            this.maxHP = hp;
            this.currentMana = mana;
            this.maxMana = mana;
            this.stats = stats;
        }
        public abstract void DoTurn(List<Player> players, List<Enemy> enemies);
        public abstract Entity ChooseTarget(List<Entity> targets);
        public abstract void Attack(Entity target);
       
        public void UseItem(Item item, Entity target)
        {
            item.Use(this, target);
        }
    }
}
