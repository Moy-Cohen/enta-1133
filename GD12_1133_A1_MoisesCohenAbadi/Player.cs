using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_MoisesCohenAbadi
{
    internal class Player
    {
        public int Score = 0;
        public int CurrentRoll = 0;
        public List<int> PlayerDicePool = new List<int> { 4, 6, 8, 10, 12, 20, 100 };
        public string PlayerName = "username";

        internal void AskName()
        {
            Console.WriteLine("Hello there!");
            Console.WriteLine("Can I ask for your name?");
            PlayerName = Console.ReadLine();
            Console.WriteLine("Nice to meet you " + PlayerName);
        }
        //Asks and stores the username of the player

        public void AvailablePlayerDice()
        {
            PlayerDicePool = new List<int> {4, 6, 8, 10, 12, 20, 100};
        }
        //Creates the avaliable dice options the player can use

        public void PlayerTurn()
        {
            Console.WriteLine("It is your turn " + PlayerName + ", good luck!");
            Console.WriteLine("Your dice options are:");
            for (int i = 0; i < PlayerDicePool.Count; i++)
            {
                Console.WriteLine($"D{PlayerDicePool[i]}");
            }
            //Lists all of the current dice options the player have

            Console.WriteLine("Please select which die you want to roll this round");
            string ChosenDie = Console.ReadLine();

            int SelectedDie;

            while (!int.TryParse(ChosenDie.Substring(1), out SelectedDie) || !PlayerDicePool.Contains(SelectedDie)) {
                Console.WriteLine("Error!");
                Console.WriteLine("Please Select from the available options.");
                ChosenDie = Console.ReadLine();
            }
            //If the player inputs an unexpected value shows an error and asks the player to choose again
            
            PlayerDicePool.Remove(SelectedDie);
            CurrentRoll = DiceRoller.RollDie(SelectedDie);
            Score += CurrentRoll;
            //Removes the last rolled die from the list for next turn

        }

        public void PlayerStats()
        {
            Console.WriteLine(PlayerName + "'s Total Score:" + Score);
        }
        //Prints player final score
    }
}
