using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab2_CohenAbadi_Moises
{
    public class DieRoller  // Creates "DieRoller" class
    {
        public int rolledNum = 0; // Variable that saves the random rolled number
        int sides = 6;  // Variable indicates the number of sides on the die

        public void RollDice()
        {
            Random random = new Random();  // Creates an instance of the rendomizer
            rolledNum = random.Next(1,sides + 1);  // Rolls a random number between one and the number of sides of the die plus one
            Console.WriteLine("Rolled Number = " + rolledNum);  // Prints the result of the randomizer
            
        }
    }
}
