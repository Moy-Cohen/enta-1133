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

            // Game start function, runs the game functions in order
        }

        public void Welcome()
        {
            string PlayerName;
            bool WantToPlay = false;
            Console.WriteLine("");
            Console.WriteLine("This game consist in rolling dice");
            Console.WriteLine("You will have a set of four dice, each with diferent numbers of sides: D6, D8, D12 and D20");
            Console.WriteLine("You will have to choose one die each round, but be careful, if you try to repeat dice or you write something else than the given options you will loose a turn.");
            Console.WriteLine("The CPU will also roll the same amount of dice, the highest roll will tanke the sum of the rolled numbers as points");
            Console.WriteLine("At the end of all four round whoever has de most points wins the game");
            Console.WriteLine("Good Luck! And Have Fun!");
            Console.WriteLine();
            Console.WriteLine("If prompted type the answer to whatever the question is and press enter");
            Console.WriteLine("");
            Console.WriteLine("Welcome Player!");
            Console.WriteLine("What is your name?");
            PlayerName = Console.ReadLine();
                // Welcomes the player and asks for their name

            Console.WriteLine("Hello " + PlayerName + "!");
            Console.WriteLine("Do You want to play a game?");
            if (Console.ReadLine() == "yes")
            {
                WantToPlay=true;
            }
            else
            {
                Goodbye();
                Environment.Exit(0);
                // Close the program. Reference Link: https://stackoverflow.com/questions/5682408/command-to-close-an-application-of-console
            }
            // Asks the player if they would like to play

        }

        public void TurnOrder()
        {
            int Turn = 0;
             
            Player User = new Player();
            Player Cpu = new Player();
            Random Random = new Random();
            Turn = Random.Next(1,3);
            
              
            if (Turn == 1)
            {
                Console.WriteLine("You go first!");
                Console.WriteLine("Player Turn");
                Console.WriteLine();
                PlayerTurn();
                CpuTurn();
                Console.WriteLine("CPU Turn");
                Console.WriteLine();
                PointTally();
                Console.WriteLine("Next Turn");
                Console.WriteLine("Player Turn");
                Console.WriteLine();
                PlayerTurn();
                Console.WriteLine("CPU Turn");
                Console.WriteLine();
                CpuTurn();
                PointTally();
                Console.WriteLine("Next Turn");
                Console.WriteLine("Player Turn");
                Console.WriteLine();
                PlayerTurn();
                Console.WriteLine("CPU Turn");
                Console.WriteLine();
                CpuTurn();
                PointTally();
                Console.WriteLine("Next Turn");
                Console.WriteLine("Player Turn");
                Console.WriteLine();
                PlayerTurn();
                Console.WriteLine("CPU Turn");
                Console.WriteLine();
                CpuTurn();
                PointTally();
                Console.WriteLine("Game Over");
            }
            else
            {
                Console.WriteLine("CPU goes first!");
                Console.WriteLine("CPU Turn");
                Console.WriteLine();
                CpuTurn();
                Console.WriteLine("Player Turn");
                Console.WriteLine();
                PlayerTurn();
                PointTally();
                Console.WriteLine("Next Turn");
                Console.WriteLine("CPU Turn");
                Console.WriteLine();
                CpuTurn();
                Console.WriteLine("Player Turn");
                Console.WriteLine();
                PlayerTurn();
                PointTally();
                Console.WriteLine("Next Turn");
                Console.WriteLine("CPU Turn");
                Console.WriteLine();
                CpuTurn();
                Console.WriteLine("Player Turn");
                Console.WriteLine();
                PlayerTurn();
                PointTally();
                Console.WriteLine("Next Turn");
                Console.WriteLine("CPU Turn");
                Console.WriteLine();
                CpuTurn();
                Console.WriteLine("Player Turn");
                Console.WriteLine();
                PlayerTurn();
                PointTally();
                Console.WriteLine("Game Over");
            }
            //Decides who goes first between the player and the CPU
        }
        internal bool PlayerD6 = false;
        internal bool PlayerD8 = false;
        internal bool PlayerD12 = false;
        internal bool PlayerD20 = false;
            // Player Dice inventory, when the bool == true, the player cannot use that die
        internal int PlayerDiceRolls = 0;
            // Stores the Rolled numbers to later calculate scores
        public void PlayerTurn()
        {

            string DieSize;
            Player Player = new Player();

            Console.WriteLine("Choose the number of sides: 6, 8, 12, or 20 ");
            Console.WriteLine();
            DieSize = Console.ReadLine();
                // Asks the player what die they want to use and display the options storing the string in "DieSize"
            if (DieSize == "6")
            {

                if (PlayerD6 == false) 
                {
                    Console.WriteLine("You Chose D6");
                    Console.WriteLine();
                    Dice PlayerRoll = new Dice();
                    PlayerRoll.Sides = 6;
                    PlayerRoll.Roll();
                    Console.WriteLine("Player Rolled: " + PlayerRoll.RolledNum);
                    Console.WriteLine();
                    PlayerDiceRolls = PlayerRoll.RolledNum;
                    
                }
                else
                {
                    Console.WriteLine("This die has been used");
                    Console.WriteLine();
                    Player.Score += 0;

                }

                PlayerD6 = true;



            }
            else if (DieSize == "8")
            {

                if (PlayerD8 == false)
                {
                    Console.WriteLine("You Chose D8");
                    Console.WriteLine();
                    Dice PlayerRoll = new Dice();
                    PlayerRoll.Sides = 8;
                    PlayerRoll.Roll();
                    Console.WriteLine("You rolled a " + PlayerRoll.RolledNum);
                    Console.WriteLine();
                    PlayerDiceRolls = PlayerRoll.RolledNum;

                }
                else
                {
                    Console.WriteLine("This die has been used");
                    Console.WriteLine();
                    Player.Score += 0;

                }

                PlayerD8 = true;
            }
            else if (DieSize == "12")
            {

                if (PlayerD12 == false)
                {
                    Console.WriteLine("You Chose D12");
                    Console.WriteLine();
                    Dice PlayerRoll = new Dice();
                    PlayerRoll.Sides = 12;
                    PlayerRoll.Roll();
                    Console.WriteLine("You rolled a " + PlayerRoll.RolledNum);
                    Console.WriteLine();
                    PlayerDiceRolls = PlayerRoll.RolledNum;

                }
                else
                {
                    Console.WriteLine("This die has been used");
                    Console.WriteLine();
                    Player.Score += 0;

                }

                PlayerD12 = true;
            }
            else if (DieSize == "20")
            {

                if (PlayerD20 == false)
                {
                    Console.WriteLine("You Chose D20");
                    Console.WriteLine();
                    Dice PlayerRoll = new Dice();
                    PlayerRoll.Sides = 6;
                    PlayerRoll.Roll();
                    Console.WriteLine("You rolled a " + PlayerRoll.RolledNum);
                    Console.WriteLine();
                    PlayerDiceRolls = PlayerRoll.RolledNum;

                }
                else
                {
                    Console.WriteLine("This die has been used");
                    Console.WriteLine();
                    Player.Score += 0;

                }

                PlayerD20 = true;
            }
            else
            {
                Console.WriteLine("Error");
            }
                /*Compares "Die Size", and rolls the selected Die.
                 *If the answer given by the player does not match with the options, console print "Error" and the player looses that turn.
                 *If the player repeats a die console print " dice repeat not allowed" and the player will loose that turn.
                 */
        }

        internal bool CpuD6 = false;
        internal bool CpuD8 = false;
        internal bool CpuD12 = false;
        internal bool CpuD20 = false;
            // CPU Dice inventory, when the bool == true, the CPU cannot use that die
        internal int CpuDiceRolls = 0;
            // Stores the Rolled numbers to later calculate scores
        public void CpuTurn()
        {
            int CpuDice = 0;
            Random CpuDiceSelect = new Random();
            CpuDice = CpuDiceSelect.Next(1,5);
            
                // CPU creates a random number between 1 and 4 which determines the dice selection
            if (CpuDice == 1)
            {
                if (CpuD6 == false)
                {
                    Console.WriteLine("CPU Chose D6");
                    Console.WriteLine();
                    Dice CpuRoll = new Dice();
                    CpuRoll.Sides = 6;
                    CpuRoll.Roll();
                    Console.WriteLine("CPU Rolled: " + CpuRoll.RolledNum);
                    Console.WriteLine();
                    CpuDiceRolls = CpuRoll.RolledNum;


                }
                else
                {
                    
                    CpuTurn();
  
                }

                CpuD6 = true;

                
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
            if ( CpuDice == 3)
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

                CpuD20 = true;
            }
        }
            /* CPU selects and rolls the die depending on the value of "CpuDice".
             * If the die was already rolled the function rolls again until an unused die is selected.
             */
        internal int PlayerTotal = 0;
        internal int CpuTotal = 0;
        public void PointTally()
        {
            Player Player1 = new Player();
            Player Cpu = new Player();

            if (PlayerDiceRolls > CpuDiceRolls)
            {
                Player1.Score += (PlayerDiceRolls + CpuDiceRolls);
            }
            else if (CpuDiceRolls > PlayerDiceRolls)
            {
                Cpu.Score += (PlayerDiceRolls + CpuDiceRolls);
            }
            else
            {
                Player1.Score += 0;
                Cpu.Score += 0;
            }

            Console.WriteLine("Player Score = " + Player1.Score);
            Console.WriteLine("CPU Score = " + Cpu.Score);
            PlayerTotal += Player1.Score;
            CpuTotal += Cpu.Score;
        }
            // Point calculator, the better roll gets points equals to the sum of both rolls

        public void Ending()
        {
            Console.WriteLine("PLayer Final Score: " + PlayerTotal);
            Console.WriteLine();
            Console.WriteLine("CPU Final Score: " + CpuTotal);
            Console.WriteLine();

            if (PlayerTotal > CpuTotal)
            {
                Console.WriteLine("Congratulations!! You Win!!");
                Console.WriteLine("Goodbye");
            }
            else if (CpuTotal > PlayerTotal)
            {
                Console.WriteLine("Cpu Wins, Better luck next time.");
            }
            else
            {
                Console.WriteLine("It is a Tie, Play again");
            }

            //Total score display, winner is announced, congratulations or better luck next time, goodbye message

        }

        public void Goodbye()
        {
            Console.WriteLine("It's Okay, let's playa another time!");
        }
            //If the player does not want to play, the console closes.

    }
}
