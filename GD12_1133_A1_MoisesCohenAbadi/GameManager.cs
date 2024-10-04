using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_MoisesCohenAbadi
{
    internal class GameManager
    {

        Player Player1 = new Player();
        CPU Computer = new CPU();
        DiceRoller Rolling = new DiceRoller();

        public bool ContinuePlaying = true;

        public void Start()
        {
            Player1.AskName();
            AskPlay();
            Rules();
            GameLoop();
            
        }

        public void AskPlay()
        {
            bool WantToPlay = false;
            string YesPlay;
            Console.WriteLine("So " + Player1.PlayerName + " What do you say we play a game?");
            Console.WriteLine("I promise it will be fun!");
            Console.WriteLine("Please Write (yes) or (no) and press enter");
            YesPlay = Console.ReadLine();
            if (YesPlay == "yes")
            {
                Console.WriteLine("Awesome!");
                Console.WriteLine("I will explain the rules");
            }
            else
            {
                Console.WriteLine("No problem, we will play next time, please press any key to exit");
                Console.ReadKey();
                Environment.Exit(0);
                // Close the program. Reference Link: https://stackoverflow.com/questions/5682408/command-to-close-an-application-of-console
            }

        }

        public void Rules()
        {
            Console.WriteLine("The game is called (Roll Some Dice!)");
            Console.WriteLine("Each game lastas 7 rounds");
            Console.WriteLine("Each of us will have a pool of 7 different dice available (D4, D6, D8, D10, D12, D20 & D100)");
            Console.WriteLine("Each round you will choose one of your available dice and roll it, I will do the same");
            Console.WriteLine("Whoever gets the higher role gets to add their rolled number to their score");
            Console.WriteLine("At the end of the game the player with the most points will be declared the winner");
            Console.WriteLine("When you are ready to start please press any key");
            Console.ReadKey();

        }

        public void GameLoop()
        {
            do
            {
                RunGame();
                FinalScore();
                PlayAgain();
            }
            while (ContinuePlaying == true);
        }

        public void RunGame()
        {
            for (int CurrentRound = 0; CurrentRound < 7; CurrentRound++)
            {
                string GoFirst;
                bool PlayerFirst = false;
                Console.WriteLine($" Round  {CurrentRound + 1}  Begins");
                Console.WriteLine("Would you like to go first " + Player1.PlayerName + "?   (yes) or (no)");
                GoFirst = Console.ReadLine();

                while (GoFirst != "yes" && GoFirst != "no")
                {
                    Console.WriteLine("Please select a valid option   (yes) or (no)");
                    GoFirst = Console.ReadLine();
                }

                PlayerFirst = GoFirst == "yes";

                if (PlayerFirst)
                {
                    Player1.PlayerTurn();
                    Computer.CPUTurn();
                }
                else if (!PlayerFirst)
                {
                    Computer.CPUTurn();
                    Player1.PlayerTurn();
                }
                Console.WriteLine($"Round {CurrentRound+1} Results:");
                Console.WriteLine(Player1.PlayerName + " you rolled " + Player1.CurrentRoll);
                Console.WriteLine("I rolled " + Computer.CurrentRoll);

                Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");

            }

        }

        public void FinalScore()
        {
            Console.WriteLine("The game is over, let's see our scores");
            Player1.PlayerStats();
            Computer.CPUStats();

            if (Player1.Score > Computer.Score)
            {
                Console.WriteLine("Congratulations!!");
                Console.WriteLine("You won!");
            }
            else if (Player1.Score < Computer.Score)
            {
                Console.WriteLine("I won, Better luck nex time!");
            }
        }

        public void PlayAgain()
        {
            string OneMoreGame;
            Console.WriteLine("Would you like to play again?    (yes) or (no)");
            OneMoreGame = Console.ReadLine();
            if (OneMoreGame == "yes")
            {
                ContinuePlaying = true;
                Player1.PlayerDicePool = new List<int> {4, 6, 8, 10, 12, 20, 100};
                Computer.CPUDicePool = new List<int> { 4, 6, 8, 10, 12, 20, 100 };
                Console.WriteLine("Let's Roll Some Dice!");
                Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            }
            else
            {
                Console.WriteLine("See you next time. Goodbye!");
                ContinuePlaying = false;
            }
        }
    }
}
