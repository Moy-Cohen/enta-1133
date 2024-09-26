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
        
        public void GameStart()
        {
            Welcome();
            TurnOrder();
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
            if (Turn == 1)
            {
                Console.WriteLine("You go first!");
                PlayerTurn();
                CpuTurn();
                PointTally();
                Console.WriteLine("Next Turn");
                PlayerTurn();
                CpuTurn();
                PointTally();
                Console.WriteLine("Next Turn");
                PlayerTurn();
                CpuTurn();
                PointTally();
                Console.WriteLine("Next Turn");
                PlayerTurn();
                CpuTurn();
                PointTally();
                Console.WriteLine("Game Ended");
            }
            else
            {
                Console.WriteLine("CPU goes first!");
                CpuTurn();
                PlayerTurn();
                PointTally();
                Console.WriteLine("Next Turn");
                CpuTurn();
                PlayerTurn();
                PointTally();
                Console.WriteLine("Next Turn");
                CpuTurn();
                PlayerTurn();
                PointTally();
                Console.WriteLine("Next Turn");
                CpuTurn();
                PlayerTurn();
                PointTally();
                Console.WriteLine("Game Ended");
            }
        }
        internal bool d6 = false;
        internal bool d8 = false;
        internal bool d12 = false;
        internal bool d20 = false;

        public void PlayerTurn()
        {
            int DieSize = 0;
            Player Player = new Player();

            Console.WriteLine("Enter the number of sided you want the die you use this round to have out of the following options: 6, 8, 12, or 20. You can only choose each option once.");
            if (Console.ReadLine() == "6")
            {

                if (d6 == false) 
                {
                    
                    Dice PlayerD6Roll = new Dice();
                    PlayerD6Roll.Sides = 6;
                    PlayerD6Roll.Roll();
                    Console.WriteLine("You rolled a " + PlayerD6Roll.RolledNum);
                    
                }
                if (d6 == true)
                {
                    Console.WriteLine("This die has already been used");
                    Player.Score += 0;

                }

                d6 = true;



            }
            else if (Console.ReadLine() == "8")
            {

                if (d8 == false)
                {

                    Dice PlayerD8Roll = new Dice();
                    PlayerD8Roll.Sides = 8;
                    PlayerD8Roll.Roll();
                    Console.WriteLine("You rolled a " + PlayerD8Roll.RolledNum);

                }
                if (d8 == true)
                {
                    Console.WriteLine("This die has already been used");
                    Player.Score += 0;

                }

                d8 = true;
            }
            else if (Console.ReadLine() == "12")
            {

                if (d12 == false)
                {

                    Dice PlayerD12Roll = new Dice();
                    PlayerD12Roll.Sides = 12;
                    PlayerD12Roll.Roll();
                    Console.WriteLine("You rolled a " + PlayerD12Roll.RolledNum);

                }
                if (d12 == true)
                {
                    Console.WriteLine("This die has already been used");
                    Player.Score += 0;

                }

                d12 = true;
            }
            else if (Console.ReadLine() == "20")
            {

                if (d20 == false)
                {

                    Dice PlayerD20Roll = new Dice();
                    PlayerD20Roll.Sides = 6;
                    PlayerD20Roll.Roll();
                    Console.WriteLine("You rolled a " + PlayerD20Roll.RolledNum);

                }
                if (d20 == true)
                {
                    Console.WriteLine("This die has already been used");
                    Player.Score += 0;

                }

                d20 = true;
            }
            else
            {
                Console.WriteLine("Error");
            }

        }

        public void CpuTurn()
        {

        }

        public void PointTally()
        {

        }

        public void Ending()
        {

        }
    }
}
