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
            Research(); // Calls function "Research"
            Outro(); // Calls function "Gameplay"

        }

        public void Welcome() 
        {
            Console.WriteLine("Hello Player"); // Prints a welcome message in the console
            Console.WriteLine("Moises Cohen Abadi - ENTA 1133"); // Prints name and course code 
            Console.WriteLine("");

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
            Console.WriteLine("");

        }

        public void Research()
        {
            Console.WriteLine("Arithmetic Operators:");
            Console.WriteLine("");
            Console.WriteLine("+:");
            Console.WriteLine("Addition: Adds two operands, a+b");
            Console.WriteLine("");
            Console.WriteLine("-:");
            Console.WriteLine("Subtraction: Substracts the second operand from the first, a-b");
            Console.WriteLine("");
            Console.WriteLine("*:");
            Console.WriteLine("Multiplication/Product: Multiplies two operands, a*b");
            Console.WriteLine("");
            Console.WriteLine("/:");
            Console.WriteLine("Division: Divides the first operand by the second, the quotient is rounded towards zero but it can be given withe the use of FLOAT, DOUBLE or DECIMAL type variables, a/b=");
            Console.WriteLine("");
            Console.WriteLine("%:");
            Console.WriteLine("Remainder: Gives the remainder after dividing the firts operand by the second operand, a%b = a-(a/b)*b");
            Console.WriteLine("");
            Console.WriteLine("++:");
            Console.WriteLine("Increment: Increments the operand by 1, 1++=2");
            Console.WriteLine("");
            Console.WriteLine("++:");
            Console.WriteLine("Decrement: Decrements the operand by 1, 2--=1");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Researched from: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators");

        }

        public void Outro()
        {
            Console.WriteLine("");
            Console.WriteLine("Thanks for playing!");  //Prints a goodbye message
            Console.WriteLine("See you next time!");  //Prints a goodbye message
        }

    }
}
