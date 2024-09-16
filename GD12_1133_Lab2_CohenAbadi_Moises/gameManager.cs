using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab2_CohenAbadi_Moises
{
    internal class GameManager
    {
        public void ProgramStart()
        {
            Welcome(); // Calls function "Welcome" 
            GamePlay(); // Calls function "Gameplay"
            Outro(); // Calls function "Gameplay"

        }

        public void Welcome() 
        {
            Console.WriteLine("Hello Player"); // Prints a welcome message in the console
            Console.WriteLine("Moises Cohen Abadi - ENTA 1133"); // Prints name and course code 

        }

        public void GamePlay()
        {
            int sum = 0; // Variable to add all rolled dice


            DieRoller roll1 = new DieRoller(); // First inscance of the dice roller 

            roll1.RollDice(); // Starts the die roller

            DieRoller roll2 = new DieRoller(); // Second inscance of the dice roller 

            roll2.RollDice(); // Starts the die roller

            DieRoller roll3 = new DieRoller(); // Third inscance of the dice roller 

            roll3.RollDice();  // Starts the die roller

            DieRoller roll4 = new DieRoller(); // Fourth inscance of the dice roller 

            roll4.RollDice();  // Starts the die roller


            sum = roll1.rolledNum + roll2.rolledNum + roll3.rolledNum + roll4.rolledNum;  // The variable "sum" adds the numbers from all the instances of the die roller
            Console.WriteLine("Total Rolled = " + sum);  // Prints the result of the "sum" variable 

        }

        public void Outro()
        {
            Console.WriteLine("Thanks for playing!");  //Prints a goodbye message
            Console.WriteLine("See you next time!");  //Prints a goodbye message
        }

    }
}
