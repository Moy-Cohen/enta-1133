using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_Lab3_CohenAbadi_Moises
{
    internal class GameManager
    {
        Player Player1 = new Player();
        Player CPU = new Player();
        Dice PLayerDice = new Dice();
        Dice CPUDice = new Dice();
            //Creating instances of the player and dice classes for the player and the CPU
        public void GameStart()
        {
            Welcome();
            
        }
        
        
        public void Welcome()
        {
            string WantToPlay;

            Console.WriteLine("Hello player! And welcome to Rolling Dice!");
            Console.WriteLine();
            Console.WriteLine("In this game you have a selection of dice with different number of faces");
            Console.WriteLine("You will have a D6, D8, D12 and D20");
            Console.WriteLine("I will have the same dice, during the game we will roll all of the dice on by one");
            Console.WriteLine("You can choose the order in which you roll your dice, but you can only use each die once");
            Console.WriteLine("After each roll we will compare the result and whoever rolls the highest gets point equal to the sum of both rolls");
            Console.WriteLine("When all four dice are rolled we will compare points and whoever has more points wins the game");
            Console.WriteLine("When answering please type your answer and press Enter to continue");
            Console.WriteLine();
            Console.WriteLine("Now, tell me about yourself, what is your name?");
            Player1.Name = Console.ReadLine();

            // This function welcomes the player, explains the game and ask for the player name.

            Console.WriteLine("So " + Player1.Name + ", would you like to play?");
            WantToPlay = Console.ReadLine();
            if (WantToPlay == "yes")
            {
                Console.WriteLine("Great! Good luck!");
            }
            else
            {
                Console.WriteLine("It's okay, we'll play another time");
                Console.WriteLine("please press any key to exit");
                Console.ReadKey();
                Environment.Exit(0);
            }
            // The game asks the player if they want to play, if yes the code keeps running, if not the program closes after player input
            //Close the program. Reference Link: https://stackoverflow.com/questions/5682408/command-to-close-an-application-of-console
        }

        public void Turn1()
        {
            string GoFirst;
            Console.WriteLine("Turn 1");
            Console.WriteLine();
            Console.WriteLine("Would you like to go first" + Player1.Name + "?");
            Console.WriteLine("Press 1 for yes or 2 for no");
            GoFirst = Console.ReadLine();
            if (GoFirst == "1")
            {
                
            }

        }

        
        
        



    }
}
