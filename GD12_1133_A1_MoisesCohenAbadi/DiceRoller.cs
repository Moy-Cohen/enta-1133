﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_MoisesCohenAbadi
{
    public class DiceRoller
    {
        public int numberOfSides = 0;
        public int rolledNumber = 0;
        
        // Random dice rolled
        public void rollDice()
        {
            Random random = new Random();
            rolledNumber = random.Next(1, numberOfSides + 1);
        }
    }
}
