using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_MoisesCohenAbadi
{
    public class ConsoleMessages
    {
        public void Intro()
        {
            Console.WriteLine("Welcome to The Minotaur's Labyrinth");
        }

        public void PlayerName()
        {
            Console.WriteLine("What is your name?");
            GameManager.Player1.playerName = Console.ReadLine();

        }

        public void Description()
        {
            Console.WriteLine("Hello " + GameManager.Player1.playerName + " and wlecome to the game The Minotaur's Labyritnth");

        }

        public void End()
        {
            Console.WriteLine("Goodbye");

        }
    }
}
