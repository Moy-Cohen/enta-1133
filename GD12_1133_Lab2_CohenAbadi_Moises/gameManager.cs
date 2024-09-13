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
            Welcome(); //Calls function "Welcome" 
            GamePlay();
            Outro();

        }

        public void Welcome() 
        {
            Console.WriteLine("Hello Player");
            Console.WriteLine("Moises Cohen Abadi - ENTA 1133");

        }

        public void GamePlay()
        {
            int sum = 0;
            int rolls = 0;
            
            DieRoller dice = new DieRoller();
            
            dice.RollDice();
            rolls++;
            sum = sum + dice.result;
            Console.WriteLine("Sum = " + sum);

            
            
        }

        public void Outro()
        {
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("See you next time!");
        }

    }
}
