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
        List<Rooms> listRooms = new List<Rooms> {new Rooms.roomTreasure(), new Rooms.roomCombat()};

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
            grid[0, 0] = listRooms[random.Next(listRooms.Count)]; // Bottom left (entrance)
            grid[1, 0] = listRooms[random.Next(listRooms.Count)]; // Bottom mid
            grid[2, 0] = listRooms[random.Next(listRooms.Count)]; // Bottom right

            grid[0, 1] = listRooms[random.Next(listRooms.Count)]; // Mid Left
            grid[1, 1] = new Rooms.roomBoss(); // Mid mid (Boss Fight Room)
            grid[2, 1] = listRooms[random.Next(listRooms.Count)]; // Mid right

            grid[0, 2] = listRooms[random.Next(listRooms.Count)]; // Top left
            grid[1, 2] = listRooms[random.Next(listRooms.Count)]; // Top mid
            grid[2, 2] = listRooms[random.Next(listRooms.Count)]; // Top right 
        }

        private void GameLoop()
        {
            int playerPositionX = 0;
            int playerPositionY = 0;
            int newPlayerPositionX = 0;
            int newPlayerPositionY = 0;
            bool gameActive = true;
            string playerAnswer = "";
            string directionChoice = "";

            // Create the map grid
            CreateGrid(); 

            // Loop while game is active the game keeps running

            while (gameActive)
            {
                if (Player1.playerIsAlive)
                {
                    //todo replace all "Jump space" for a transition
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Welcome " + Player1.playerName);
                    Console.WriteLine($"You entered the Dungeon, you find yourself in the {grid[playerPositionX, playerPositionY].roomName}");
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    Console.WriteLine("Select your next action from the following options:");
                    Console.WriteLine("1. Move to another room");
                    Console.WriteLine("2. Search the current room");
                    Console.WriteLine("3. Review your inventory");
                    Console.WriteLine("4. Check your Hit points (Hp)");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("5. Exit game");
                    // Save player input
                    playerAnswer = (Console.ReadLine() ?? "");
                    Console.WriteLine();
     
                    // Switch for the playerAnswer variable
                    switch (playerAnswer)
                    {
                        case "1": // Move to another room
                            bool validDirection = true;
                            Console.WriteLine("Where do you want to move?");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("1. North");
                            Console.WriteLine("2. East");
                            Console.WriteLine("3. South");
                            Console.WriteLine("4. West");
                            Console.ResetColor();
                            // Save player input
                            directionChoice = (Console.ReadLine() ?? "");
                            Console.WriteLine();

                            // Reassign variable values
                            newPlayerPositionX = playerPositionX;
                            newPlayerPositionY = playerPositionY;

                            // Switch to choose direction
                            switch (directionChoice)
                            {
                                case "1":
                                    newPlayerPositionY++;
                                    directionChoice = "North";
                                    break;
                                case "2":
                                    newPlayerPositionX++;
                                    directionChoice = "East";
                                    break;
                                case "3":
                                    newPlayerPositionY--;
                                    directionChoice = "South";
                                    break;
                                case "4":
                                    newPlayerPositionX--;
                                    directionChoice = "West";
                                    break;
                                default:
                                    Console.ForegroundColor= ConsoleColor.Red;
                                    Console.WriteLine("Error: invalid choice.");
                                    Console.WriteLine("please Select 1. North | 2. East | 3. South | 4. West");
                                    validDirection = false;
                                    break;
                            }
                            if (validDirection)
                            {
                                // Check if new player position is inside the grid
                                if (newPlayerPositionX >= 0 && newPlayerPositionX < 3 && newPlayerPositionY >= 0 && newPlayerPositionY < 3)
                                {
                                    // Call room exit function
                                    grid[playerPositionX, playerPositionY].onExitingRoom();

                                    // Reassign variables values
                                    playerPositionX = newPlayerPositionX;
                                    playerPositionY = newPlayerPositionY;

                                    Console.Write("You moved to ");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine(directionChoice);
                                    Console.ResetColor();

                                    // Call function room entered
                                    grid[playerPositionX,playerPositionY].onEnteringRoom();
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("You can not go ");
                                    Console.Write(directionChoice);
                                    Console.WriteLine(". It is outside of the dungeon boundries");
                                    Console.WriteLine();
                                    Console.ResetColor();
                                }
                            }
                            break;

                        case "2": // Search current room
                            // Call function for searching the room
                            grid[playerPositionX, playerPositionY].onSearchingRoom();
                            break;
                        case "3": // Check player inventory
                            Player1.playerInventory.checkInventory();
                            Console.WriteLine();
                            break;
                        case "4": // Check player Hit points
                            Console.WriteLine("Hit points:");
                            Console.ForegroundColor= ConsoleColor.Cyan;
                            Console.Write(Player1.playerName + "You currently have: ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(Player1.playerHp);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(" Hit points");
                            break;
                        case "5": // Exit game
                            Console.WriteLine();
                            Console.WriteLine("You decided to give up and quit the game");
                            Console.WriteLine("Play again Soon");
                            gameActive = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: invalid choice");
                            Console.WriteLine("Please select of the following options 1 | 2 | 3 | 4 | 5 ");
                            Console.WriteLine();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("GAME OVER!");
                    Console.WriteLine("Would you like to play again?");
                    Console.ResetColor();
                    Console.WriteLine("Please select YES | NO");
                    playerAnswer = (Console.ReadLine() ?? "").ToLower();

                    // Switch to play again
                    switch(playerAnswer)
                    {
                        case "yes":
                            Console.WriteLine();
                            Console.WriteLine("Restarting game ...");

                            // reset player position
                            playerPositionX = 0;
                            playerPositionY = 0;

                            // Reset player stats
                            Player1.resetStats();

                            //Create a new grid map
                            CreateGrid();
                            break;
                        case "no": 
                            Console.WriteLine();
                            gameActive = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: invalid option");
                            Console.WriteLine("Please select YES | NO");
                            Console.ResetColor();
                            Console.WriteLine();
                            break;

                    }
                }
            }


        }
    }
}
