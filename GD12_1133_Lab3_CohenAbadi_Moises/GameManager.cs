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
        }

        public void AskPlay()
        {
            string WantToPlay;
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

        public void TurnOrder()
        {
            int GoesFirst = 0;
            Random Random = new Random();
            GoesFirst = Random.Next(1, 3);

            if (GoesFirst == 1)
            {
                Console.WriteLine(Player1.Name + ", You go First");
                //PlayerTurn1();
            }
            else
            {
                Console.WriteLine("I play first");
                CPUTurn();
            }

        }

        public void CPUTurn()
        {
            int CpuDice = 0;
            Random CpuDiceSelect = new Random();
            CpuDice = CpuDiceSelect.Next(1, 5);

            // CPU creates a random number between 1 and 4 which determines the dice selection
            /*
            if (CpuDice == 1)
            {
                if (CPU.D6 == false)
                {
                    Console.WriteLine("CPU Chose D6");
                    Console.WriteLine();
                    CPUDice.Sides = 6;
                    Console.WriteLine("I rolled " + CPUDice.Roll(CPUDice.Sides));

                }
                else
                {

                    CpuTurn();

                }

                CPU.D6 = true;


            }

            if (CpuDice == 2)
            {
                if (CpuD8 == false)
                {
                    Console.WriteLine("CPU Chose D8");
                    Console.WriteLine();
                    Dice CpuRoll = new Dice();
                    CpuRoll.Sides = 8;
                    CpuRoll.Roll();
                    Console.WriteLine("CPU Rolled: " + CpuRoll.RolledNum);
                    Console.WriteLine();
                    CpuDiceRolls = CpuRoll.RolledNum;

                }
                else
                {

                    CpuTurn();

                }

                CpuD8 = true;

            }
            if (CpuDice == 3)
            {
                if (CpuD12 == false)
                {
                    Console.WriteLine("CPU Chose D12");
                    Console.WriteLine();
                    Dice CpuRoll = new Dice();
                    CpuRoll.Sides = 12;
                    CpuRoll.Roll();
                    Console.WriteLine("CPU Rolled: " + CpuRoll.RolledNum);
                    Console.WriteLine();
                    CpuDiceRolls = CpuRoll.RolledNum;

                }
                else
                {


                    CpuTurn();

                }

                CpuD12 = true;

            }

            if (CpuDice == 4)
            {
                if (CpuD20 == false)
                {
                    Console.WriteLine("CPU Chose D20");
                    Console.WriteLine();
                    Dice CpuRoll = new Dice();
                    CpuRoll.Sides = 20;
                    CpuRoll.Roll();
                    Console.WriteLine("CPU Rolled: " + CpuRoll.RolledNum);
                    Console.WriteLine();
                    CpuDiceRolls = CpuRoll.RolledNum;

                }
                else
                {


                    CpuTurn();

                }

                CPUD20 = true; 
            }*/
        }











    }
}
