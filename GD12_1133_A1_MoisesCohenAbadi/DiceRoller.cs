    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_MoisesCohenAbadi
{
    internal class DiceRoller
    {
        public static int RollDie(int sides)
        {
            Random RandomRoll = new Random();
            return RandomRoll.Next(1, sides + 1);
        }
        // Random numer generator that functions as the dice in the game

    }
}
