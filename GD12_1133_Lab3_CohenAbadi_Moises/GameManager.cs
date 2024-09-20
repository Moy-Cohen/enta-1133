using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab3_CohenAbadi_Moises
{
    internal class GameManager
    {
        
        public void GameStart()
        {
            Welcome();
            TurnOrder();
            GamePlay();
            Ending();
        }

        public void Welcome()
        {
            string PlayerName;
            bool WantToPlay = false;
            Console.WriteLine("");
            Console.WriteLine("If prompted type the answer to whatever question and press enter");
            Console.WriteLine("");
            Console.WriteLine("Welcome Player!");
            Console.WriteLine("What is your name?");
            PlayerName = Console.ReadLine();
            Console.WriteLine("Hello " + PlayerName + "!");
            Console.WriteLine("Do You want to play a game?");
            if (Console.ReadLine() == "yes")
            {
                WantToPlay=true;
            }
            else
            {
                Ending();
            }
            Console.WriteLine(WantToPlay);
            


        }

        public void TurnOrder()
        {
            int Turn = 0;
             
            Player User = new Player();
            Player Cpu = new Player();
            Random Random = new Random();
            Turn = Random.Next(1,3);
            Console.WriteLine(Turn);    
        }

        public void GamePlay()
        {

        }

        public void Ending()
        {

        }
    }
}
