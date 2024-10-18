using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_MoisesCohenAbadi
{
    public abstract class Items
    {
        public DiceRoller dice = new DiceRoller();
        public abstract string itemName { get; }
        public abstract bool itemConsumes { get; }

    }

    
    public abstract class Weapons : Items
    {
        public override bool itemConsumes { get; } = false;
        public abstract int weaponUses { get; }
        public abstract int maxDamage { get; }
        public abstract void weaponDamage(ref int damage);
    }

    public abstract class Consumables : Items
    {
        public override bool itemConsumes { get; } = true;
        public abstract int maxHeal { get; } 
        public abstract void heal(ref int playerHeals);
    }

    // Weapons heritages
    public class Sword : Weapons
    {
        public override string itemName { get; } = "Sword";
        Random uses = new Random();
        public override int weaponUses { get; } = 2;
        public override int maxDamage { get; } = 8;
        public override void weaponDamage(ref int damage)
        {
            dice.numberOfSides = maxDamage;
            damage = dice.rollDice(maxDamage);
        }
    }

    public class Dagger : Weapons
    {
        public override string itemName { get; } = "Dagger";
        Random uses = new Random();
        public override int weaponUses { get; } = 1;
        public override int maxDamage { get; } = 4;
        public override void weaponDamage(ref int damage)
        {
            dice.numberOfSides = maxDamage;
            dice.rollDice(maxDamage);
        }
    }

    public class BattleAxe : Weapons
    {
        public override string itemName { get; } = "BattleAxe";
        Random uses = new Random();
        public override int weaponUses { get; } = 5;
        public override int maxDamage { get; } = 12;
        public override void weaponDamage(ref int damage)
        {
            dice.numberOfSides = maxDamage;
            dice.rollDice(maxDamage);
        }
    }

    public class LongSword : Weapons
    {
        public override string itemName { get; } = "LongSword";
        Random uses = new Random();
        public override int weaponUses { get; } = 3;
        public override int maxDamage { get; } = 10;
        public override void weaponDamage(ref int damage)
        {
            dice.numberOfSides = maxDamage;
            dice.rollDice(maxDamage);
        }
    }


    // Consumables heritages
    public class HealthPotion : Consumables
    {
        public override string itemName { get; } = "HealthPotion";
        public override int maxHeal { get; } = 5;
        public override void heal(ref int playerHeals)
        {
          dice.numberOfSides = maxHeal;
          dice.rollDice(maxHeal);
        }
    }

    public class GreatHealthPotion : Consumables
    {
        public override string itemName { get; } = "GreatHealthPotion";
        public override int maxHeal { get; } = 10;
        public override void heal(ref int playerHeals)
        {
            dice.numberOfSides = maxHeal;
            dice.rollDice(maxHeal);
        }
    }

    public class UltraHealthPotion : Consumables
    {
        public override string itemName { get; } = "UltraHealthPotion";
        public override int maxHeal { get; } = 20;
        public override void heal(ref int playerHeals)
        {
            dice.numberOfSides = maxHeal;
            dice.rollDice(maxHeal);
        }
    }
}
