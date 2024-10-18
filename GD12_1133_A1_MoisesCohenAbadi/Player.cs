using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_MoisesCohenAbadi
{
    public class Player
    {
        public string playerName = "";
        public int playerHp = 50;
        public int score = 0;
        public bool playerIsAlive = true;

        //Create player inventory
        public Inventory playerInventory = new Inventory();


        // Function to reference player's hit points
        public void playerHpCheck()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(playerName);
            Console.ResetColor();
            Console.WriteLine(" currently has ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(playerHp + "Hit points");
            Console.ResetColor();
        }

        // Function to calculate damage taken by the player
        public void damageTaken(int damage)
        {
            playerHp -= damage;

            // if playerHp is less or equal to 0 player dies
            if (playerHp <= 0)
            {
                playerIsAlive = false;
                playerHp = 0;
            }
        }


        // Reset player stats
        public void resetStats()
        {
            playerHp = 50;
            score = 0;
            playerIsAlive = true;
            //clear inventory
        }
    }
}
