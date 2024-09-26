using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab3_CohenAbadi_Moises
{
   
    internal class Dice
    {
        public int Sides = 0;
        public int RolledNum = 0;

        public void Roll()
        {

            Random Random = new Random();
            RolledNum = Random.Next(1, Sides + 1);

        }
    }

    
}
