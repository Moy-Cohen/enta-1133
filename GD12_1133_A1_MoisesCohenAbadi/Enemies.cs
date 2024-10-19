using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_MoisesCohenAbadi
{
    public abstract class Enemies
    {
        internal DiceRoller dice = new DiceRoller();
        public abstract string monsterName { get; }
        public abstract int monsterHp { get; set;  }
        public abstract int Attack();

        public static Enemies RandomMonster()
        {
            Random random = new Random();

            // Create list of monsters with the same probablity of each of the monsters appearing

            List<Enemies> monsterList = new List<Enemies>();

            // Each type of monster has a 25% chance of appearing in a combat room

            for (int i = 0; i < 25; i++)
            {
                monsterList.Add(new Skeleton());
            }

            for (int i = 0; i < 25; i++)
            {
                monsterList.Add(new Zombie());
            }

            for (int i = 0; i < 25; i++)
            {
                monsterList.Add(new GiantSpider());
            }

            for (int i = 0; i < 25; i++)
            {
                monsterList.Add(new GelatinousCube());
            }
            

            return monsterList[random.Next(monsterList.Count)]; // Returns a random monster from the list
        }

        public static Enemies Boss()
        {
            Random random = new Random();
            List <Enemies> BossMonster = new List<Enemies>();
            BossMonster.Add(new bossMinotaur());

            return BossMonster[random.Next(BossMonster.Count)];
        }

        
        // Returns if the monster is alive
        public bool MonsterAlive()
        {
            if (monsterHp > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Function to calculate damage taken by the monsters
        public void DamageTaken(int takeDamage)
        {
            monsterHp -= takeDamage;

            // If monsterHP is less than 0 reassign to be equal to 0
            if (monsterHp <= 0)
            {
                monsterHp = 0;
            }
            // Displays the damage taken and the Hp remaining
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(monsterName);
            Console.ResetColor();
            Console.Write(" has taken ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(takeDamage);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(monsterName);
            Console.ResetColor();
            Console.Write(" has ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(monsterHp);
            Console.ResetColor();
            Console.WriteLine(" remaining");

        }
        
        
   
    }

    public class Skeleton : Enemies
    {
        public override string monsterName { get; } = "Skeleton"; // Overrides monster name

        
        public override int monsterHp { get; set; } = 20; // Overrides monster Hp
        public override int Attack()
        {
            dice.numberOfSides = 10;
            int damageDealt = dice.rollDice(10);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(monsterName);
            Console.ResetColor();
            Console.Write(" attacks with a rusty sword and deals");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(damageDealt);
            Console.WriteLine();
            return damageDealt;
        }
    }

    public class Zombie : Enemies
    {
        public override string monsterName { get; } = "Zombie"; // Overrides monster name

        public override int monsterHp { get; set; } = 25; // Overrides monster Hp
        public override int Attack()
        {
            dice.numberOfSides = 8;
            int damageDealt = dice.rollDice(8);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(monsterName);
            Console.ResetColor();
            Console.Write(" bites you and deals");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(damageDealt);
            Console.WriteLine();
            return damageDealt;
        }
    }

    public class GiantSpider : Enemies
    {
        public override string monsterName { get; } = "Giant Spider"; // Overrides monster name

        public override int monsterHp { get; set; } = 30; // Overrides monster Hp
        public override int Attack()
        {
            dice.numberOfSides = 12;
            int damageDealt = dice.rollDice(12);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(monsterName);
            Console.ResetColor();
            Console.Write(" uses it's pincers to bite you and deals");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(damageDealt);
            Console.WriteLine();
            return damageDealt;
        }
    }


    public class GelatinousCube : Enemies
    {
        public override string monsterName { get; } = "Gelatinous Cube"; // Overrides monster name

        public override int monsterHp { get; set; } = 45; // Overrides monster Hp
        public override int Attack()
        {
            dice.numberOfSides = 12;
            int damageDealt = dice.rollDice(12);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(monsterName);
            Console.ResetColor();
            Console.Write(" jumps on top of you and deals");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(damageDealt);
            Console.WriteLine();
            return damageDealt;
        }
    }

    public class bossMinotaur : Enemies
    {
        public override string monsterName { get; } = "Minotaur"; // Overrides monster name
        public override int monsterHp { get; set; } = 75; // Overrides monster Hp
        public override int Attack()
        {
            dice.numberOfSides = 25;
            int damageDealt = dice.rollDice(25);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(monsterName);
            Console.ResetColor();
            Console.Write(" attacks with it's horns and deals");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(damageDealt);
            Console.WriteLine();
            return damageDealt;

        }

    }

    


}
