using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_MoisesCohenAbadi
{
    public abstract class Rooms
    {
        public abstract string roomName { get; }
        public string foundItem = "";

        // Display the room that the player entered
        public virtual void onEnteringRoom()
        {
            
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("You just entered a ");
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine(roomName);
            Console.ResetColor();
        }

        public abstract void onSearchingRoom();
        
        // Display the room the player is exiting
        public virtual void onExitingRoom()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("You are leaving ");
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine(roomName);
            Console.ResetColor();

        }

        public class roomTreasure : Rooms
        {
            public override string roomName { get; } = "Treasure Room";
            bool roomSearched = false;
            public override void onEnteringRoom()
            {
                base.onEnteringRoom(); // Calling the base function 
            }

            public override void onSearchingRoom()
            {
                if (!roomSearched)
                {
                    // For loop that gives one item each time it runs
                    for (int i = 0; i < 3; i++)
                    {
                        GameManager.Player1.playerInventory.addToInventory(ref foundItem);
                        Console.Write("You found: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(foundItem);
                        Console.ResetColor();
                    }
                    
                }
                else if (roomSearched)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have already searched this room");
                    Console.ResetColor();
                }
            }
        }

        public class roomCombat : Rooms
        {
            public override string roomName { get; } = "Combat Room";
            bool playerWin = false;
            bool wantToFight = false;
            string playerAnswer = "";
            bool roomSearched = false;

            //Dice insance
            DiceRoller dice = new DiceRoller();

            public override void onEnteringRoom()
            {
                wantToFight = false;
                base.onEnteringRoom(); // Calling the base function
                GameManager.Player1.playerHpCheck();

                //While player wants to fight, start loop that runs game loop
                while (wantToFight != true)
                {
                    Console.WriteLine("Do you want to start combat?");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Type YES | NO");
                    Console.ResetColor();
                    playerAnswer = (Console.ReadLine() ?? "").ToLower();

                    switch (playerAnswer)
                    {
                        case "yes":
                            wantToFight=true;
                            // Creates a variable to assign the random monster
                            Enemies monster = Enemies.RandomMonster();

                            // Display message of the type of monster the player is fighting
                            Console.Write("You are fighting against a");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(monster.monsterName);
                            Console.ResetColor();
                            Console.Write(" which has ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(monster.monsterHp + "Hp");

                            //Combat loop while player and monster are alive
                            while (GameManager.Player1.playerIsAlive && monster.MonsterAlive())
                            {
                                PlayerTurn(monster); // Calls player turn function

                                // If monster dies the loop ends
                                if (monster.MonsterAlive() != true)
                                {
                                    break;
                                }
                                MonsterTurn(monster); // Calls monster tunr function
                            }

                            playerWinLoose(monster);
                            break;

                        case "no":
                            Console.WriteLine();
                            Console.WriteLine("Okay, you can keep going");
                            wantToFight = true;
                            playerWin = false;
                            break;
                        default:
                            Console.ForegroundColor= ConsoleColor.Cyan;
                            Console.WriteLine("Please select a valid answer. Type YES | NO");
                            Console.ResetColor();
                            Console.WriteLine();
                            break;
                    }
                }

            }

            void PlayerTurn(Enemies monster)
            {
                int playerHeals = 0;
                int playerDamage = 0;
                int playerChoice = 0;
                bool isChoiceValid = false;
                string input = "";

                // Check for weapons and consumables on the player's inventory
                List<Weapons> weapons = GameManager.Player1.playerInventory.GetWeapons();
                List<Consumables> consumables = GameManager.Player1.playerInventory.GetConsumables();

                Weapons selectWeapon = null;
                Consumables selectConsumable = null;

                if (GameManager.Player1.playerHp > 50)
                {
                    Console.WriteLine();
                    GameManager.Player1.playerHpCheck();
                    Console.WriteLine("Choose a consumable to heal yourself");
                    for (int i = 0; i < weapons.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($" {i+ 1}: {consumables[i].itemName}");
                        Console.ResetColor();
                    }
                    isChoiceValid = false;

                    //While Choice is valid is false run this loop to select a consumable
                    while ( !isChoiceValid )
                    {
                        Console.ForegroundColor= ConsoleColor.Cyan;
                        Console.WriteLine("Pick a number");
                        input = (Console.ReadLine() ?? "");
                        // check if the player input is greater or equal the 1 and less or equal then the list count
                        if (int.TryParse(input, out playerChoice) && playerChoice >= 1 && playerChoice <= consumables.Count + 1)
                        {
                            isChoiceValid= true;
                        }
                        else
                        {
                            Console.ForegroundColor=(ConsoleColor) ConsoleColor.Cyan;
                            Console.WriteLine("Please select a valid answer. Pick a number");
                            Console.ResetColor();
                        }
                    }

                    if (playerChoice <= consumables.Count && consumables.Count> 0)
                    {
                        selectConsumable = consumables[playerChoice - 1]; // Assings selected consumables according to player choice

                    }
                }


                if (selectConsumable == null && GameManager.Player1.playerHp <50)
                {
                    Console.ForegroundColor =(ConsoleColor) ConsoleColor.Cyan;
                    Console.WriteLine("You dont have any potions, look for some potions to heal yourself");
                    Console.ResetColor ();

                }
                else if (selectConsumable != null && GameManager.Player1.playerHp > 50)
                {
                    // Calls function heal
                    playerHeals = selectConsumable.Heal();
                    GameManager.Player1.playerHp += playerHeals;
                    Console.WriteLine();
                    Console.Write("You used ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(selectConsumable.itemName);
                    Console.ResetColor();
                    Console.Write(" You healed ");
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine(playerHeals + " Hp");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(selectConsumable.itemName);
                    Console.ResetColor();
                    Console.WriteLine("Has been used and it is no longer available");
                    GameManager.Player1.playerInventory.removeFromInventory(selectConsumable); // Removes used item from inventory
                }

                // If statement to choose weapon
                if (weapons.Count >= 0)
                {
                    // Loop prints the list of available weapon options
                    Console.WriteLine();
                    GameManager.Player1.playerHpCheck();
                    Console.ForegroundColor=(ConsoleColor) ConsoleColor.Cyan;
                    Console.WriteLine("Pick your weapon");
                    Console.ResetColor ();
                    for (int i = 0; i < weapons.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{i+1}: {weapons[i].itemName}");
                        
                    }
                    // If there are no weapons available you can use an unarmed strike to attack
                    Console.WriteLine ($"{weapons.Count + 1}: Unarmed Strike");
                    Console.ResetColor ();
                    isChoiceValid = false;
                }
                // While choice is valid = false keep runing the loop
                while(!isChoiceValid)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Choose your weapon");
                    if (int.TryParse(input, out playerChoice) && playerChoice >= 1 && playerChoice <= weapons.Count)
                    {
                        isChoiceValid=true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Invalid choice. Please choose a weapon");
                        Console.ResetColor();
                    }

                }

                if (selectWeapon == null || (weapons.Count > 0 && playerChoice == weapons.Count + 1))
                {
                    // If there are no weapons, player attack with unarmed strike
                    Console.WriteLine ();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("You Chose an unarmed strike");
                    Console.ResetColor ();
                    dice.numberOfSides = 4;
                    playerDamage = dice.rollDice(4);
                    Console.Write("You dealt ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(playerDamage + " Hp");
                }
                else
                {
                    //Player attacks with the selected weapon
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("You attacked with ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(selectWeapon.itemName);
                    dice.numberOfSides = selectWeapon.maxDamage;
                    playerDamage = dice.rollDice(selectWeapon.maxDamage);
                    Console.Write("You dealt ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(playerDamage + " Hp");
                }

                // Monster takes damage dealt by player
                monster.DamageTaken(playerDamage);
            }

            // Function enemy turn
            void MonsterTurn(Enemies monster)
            {
                int enemyDamage = monster.Attack();
                GameManager.Player1.damageTaken(enemyDamage);
            }

            // Function to chek if the player wins or loses
            void playerWinLoose(Enemies monster)
            {
                if (monster.MonsterAlive() == false) // Player Wins
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("You defeated the ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(monster.monsterName);
                    Console.ResetColor();
                    playerWin = true;
                }
                else if (GameManager.Player1.playerIsAlive == false)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("You Died");
                    Console.ResetColor();
                    playerWin = false;
                }                
            }

            public override void onSearchingRoom()
            {
                if (playerWin == true && !roomSearched)
                {
                    GameManager.Player1.playerInventory.addToInventory(ref foundItem);
                    Console.Write("You found ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(foundItem);
                    roomSearched = true;
                }
                else if (roomSearched)
                {
                    Console.WriteLine("This room has been searche already");
                }
            }



        }

       /* public class roomBoss : Rooms
        {
            public override string roomName { get; } = "Boss Battle Room";
            Enemies Boss = Enemies.BossMinotaur();
            bool playerWin = false;
            bool wantToFight = false;
            string playerAnswer = "";
            bool roomSearched = false;
            public bool isMinotaurDead = false;

            //Dice insance
            DiceRoller dice = new DiceRoller();

            public override void onEnteringRoom()
            {
                wantToFight = false;
                base.onEnteringRoom(); // Calling the base function
                GameManager.Player1.playerHpCheck();

                //While player wants to fight, start loop that runs game loop
                while (wantToFight != true)
                {
                    Console.WriteLine("Do you want to start combat?");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Type YES | NO");
                    Console.ResetColor();
                    playerAnswer = (Console.ReadLine() ?? "").ToLower();

                    switch (playerAnswer)
                    {
                        case "yes":
                            wantToFight = true;
                            // Creates a variable to assign the random monster
                            Enemies boss = Enemies.BossMinotaur();

                            // Display message of the type of monster the player is fighting
                            Console.Write("You are fighting against a");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(boss.monsterName);
                            Console.ResetColor();
                            Console.Write(" which has ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(boss.monsterHp + "Hp");

                            //Combat loop while player and monster are alive
                            while (GameManager.Player1.playerIsAlive && boss.MonsterAlive())
                            {
                                PlayerTurn(boss); // Calls player turn function

                                // If monster dies the loop ends
                                if (boss.MonsterAlive() != true)
                                {
                                    break;
                                }
                                MonsterTurn(boss); // Calls monster tunr function
                            }

                            playerWinLoose(boss);
                            break;

                        case "no":
                            Console.WriteLine();
                            Console.WriteLine("Okay, you can keep going");
                            wantToFight = true;
                            playerWin = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Please select a valid answer. Type YES | NO");
                            Console.ResetColor();
                            Console.WriteLine();
                            break;
                    }
                }

            }

            void PlayerTurn(Enemies boss)
            {
                int playerHeals = 0;
                int playerDamage = 0;
                int playerChoice = 0;
                bool isChoiceValid = false;
                string input = "";

                // Check for weapons and consumables on the player's inventory
                List<Weapons> weapons = GameManager.Player1.playerInventory.GetWeapons();
                List<Consumables> consumables = GameManager.Player1.playerInventory.GetConsumables();

                Weapons selectWeapon = null;
                Consumables selectConsumable = null;

                if (GameManager.Player1.playerHp > 50)
                {
                    Console.WriteLine();
                    GameManager.Player1.playerHpCheck();
                    Console.WriteLine("Choose a consumable to heal yourself");
                    for (int i = 0; i < weapons.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($" {i + 1}: {consumables[i].itemName}");
                        Console.ResetColor();
                    }
                    isChoiceValid = false;

                    //While Choice is valid is false run this loop to select a consumable
                    while (!isChoiceValid)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Pick a number");
                        input = (Console.ReadLine() ?? "");
                        // check if the player input is greater or equal the 1 and less or equal then the list count
                        if (int.TryParse(input, out playerChoice) && playerChoice >= 1 && playerChoice <= consumables.Count + 1)
                        {
                            isChoiceValid = true;
                        }
                        else
                        {
                            Console.ForegroundColor = (ConsoleColor)ConsoleColor.Cyan;
                            Console.WriteLine("Please select a valid answer. Pick a number");
                            Console.ResetColor();
                        }
                    }

                    if (playerChoice <= consumables.Count && consumables.Count > 0)
                    {
                        selectConsumable = consumables[playerChoice - 1]; // Assings selected consumables according to player choice

                    }
                }


                if (selectConsumable == null && GameManager.Player1.playerHp < 50)
                {
                    Console.ForegroundColor = (ConsoleColor)ConsoleColor.Cyan;
                    Console.WriteLine("You dont have any potions, look for some potions to heal yourself");
                    Console.ResetColor();

                }
                else if (selectConsumable != null && GameManager.Player1.playerHp > 50)
                {
                    // Calls function heal
                    playerHeals = selectConsumable.Heal();
                    GameManager.Player1.playerHp += playerHeals;
                    Console.WriteLine();
                    Console.Write("You used ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(selectConsumable.itemName);
                    Console.ResetColor();
                    Console.Write(" You healed ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(playerHeals + " Hp");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(selectConsumable.itemName);
                    Console.ResetColor();
                    Console.WriteLine("Has been used and it is no longer available");
                    GameManager.Player1.playerInventory.removeFromInventory(selectConsumable); // Removes used item from inventory
                }

                // If statement to choose weapon
                if (weapons.Count >= 0)
                {
                    // Loop prints the list of available weapon options
                    Console.WriteLine();
                    GameManager.Player1.playerHpCheck();
                    Console.ForegroundColor = (ConsoleColor)ConsoleColor.Cyan;
                    Console.WriteLine("Pick your weapon");
                    Console.ResetColor();
                    for (int i = 0; i < weapons.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{i + 1}: {weapons[i].itemName}");

                    }
                    // If there are no weapons available you can use an unarmed strike to attack
                    Console.WriteLine($"{weapons.Count + 1}: Unarmed Strike");
                    Console.ResetColor();
                    isChoiceValid = false;
                }
                // While choice is valid = false keep runing the loop
                while (!isChoiceValid)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Choose your weapon");
                    if (int.TryParse(input, out playerChoice) && playerChoice >= 1 && playerChoice <= weapons.Count)
                    {
                        isChoiceValid = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Invalid choice. Please choose a weapon");
                        Console.ResetColor();
                    }

                }

                if (selectWeapon == null || (weapons.Count > 0 && playerChoice == weapons.Count + 1))
                {
                    // If there are no weapons, player attack with unarmed strike
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("You Chose an unarmed strike");
                    Console.ResetColor();
                    dice.numberOfSides = 4;
                    playerDamage = dice.rollDice(4);
                    Console.Write("You dealt ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(playerDamage + " Hp");
                }
                else
                {
                    //Player attacks with the selected weapon
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("You attacked with ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(selectWeapon.itemName);
                    dice.numberOfSides = selectWeapon.maxDamage;
                    playerDamage = dice.rollDice(selectWeapon.maxDamage);
                    Console.Write("You dealt ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(playerDamage + " Hp");
                }

                // Monster takes damage dealt by player
                boss.DamageTaken(playerDamage);
            }

            // Function enemy turn
            void MonsterTurn(Enemies boss)
            {
                int enemyDamage = boss.Attack();
                GameManager.Player1.damageTaken(enemyDamage);
            }

            // Function to chek if the player wins or loses
            void playerWinLoose(Enemies boss)
            {
                if (boss.MonsterAlive() == false) // Player Wins
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("You defeated the ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(boss.monsterName);
                    Console.ResetColor();
                    playerWin = true;
                    isMinotaurDead = true;
                }
                else if (GameManager.Player1.playerIsAlive == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You Died");
                    Console.ResetColor();
                    playerWin = false;
                }
            }

            public override void onSearchingRoom()
            {
                if (playerWin == true && !roomSearched)
                {
                    GameManager.Player1.playerInventory.addToInventory(ref foundItem);
                    Console.Write("You found ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(foundItem);
                    roomSearched = true;
                }
                else if (roomSearched)
                {
                    Console.WriteLine("This room has been searche already");
                }
            }

        }*/
    }

}
