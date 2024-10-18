using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_MoisesCohenAbadi
{
    public class GameManager
    {
        // Create the necessary instances
        public static Player Player1 = new Player(); // Global Instance of the player
        ConsoleMessages messages = new ConsoleMessages(); // Local instance of ConsoleMessages
        Random random = new Random(); // Local Random instance


        // Create a list of the rooms
        List<Rooms> listRooms = new List<Rooms> {new Rooms.roomTreasure(), new Rooms.roomCombat(), /*new Rooms.roomBoss()*/ };

        Rooms[,] grid = new Rooms[3, 3];
        public void startGame()
        {
            messages.Intro();
            messages.PlayerName();
            messages.Description();
            GameLoop();
            messages.End();

        }

        private void CreateGrid()
        {
            grid[0, 0] = listRooms[random.Next(listRooms.Count)]; // Bottom left
            grid[1, 0] = listRooms[random.Next(listRooms.Count)]; // Bottom mid
            grid[2, 0] = listRooms[random.Next(listRooms.Count)]; // Bottom right

            grid[0, 1] = listRooms[random.Next(listRooms.Count)]; // Mid Left
            grid[1, 1] = listRooms[random.Next(listRooms.Count)]; //new Rooms.roomBoss(); // Mid mid (Start Room)
            grid[2, 1] = listRooms[random.Next(listRooms.Count)]; // Mid right

            grid[0, 2] = listRooms[random.Next(listRooms.Count)]; // Top left
            grid[1, 2] = listRooms[random.Next(listRooms.Count)]; // Top mid
            grid[2, 2] = listRooms[random.Next(listRooms.Count)]; // Top right 
        }

        private void GameLoop()
        {

        }
    }
}
