using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab2_CohenAbadi_Moises
{
    public class DieRoller
    {
        public int result = 0;
        int sides = 6;

        public void RollDice()
        {
            Random random = new Random();
            result = random.Next(1,sides + 1);
            Console.WriteLine("result = " + result);
            
        }
    }
}
