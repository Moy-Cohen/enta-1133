using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab1_CohenAbadi_Moises
{
    internal class GameManager
    {
        private int score = 0;

        private void OnPointAcquired()
        {
            score++;
            string gainedMessage = "You gained a point!";
            Console.WriteLine(gainedMessage);
        }

        public void PlayGame()
        {
            Console.WriteLine("Welcome to Die vs Die!");
            OnPointAcquired();
        }

       

    }
}
