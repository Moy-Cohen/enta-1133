using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_MoisesCohenAbadi
{
    public class Inventory
    {
        public List<Items> inventoryList = new List<Items>();

        Items randomItem()
        {
            Random random = new Random();

            List<Items> lootTable = new List<Items>();

            // Add swords for a 15% chance to drop
            for (int i = 0; i < 15; i++)
            {
                lootTable.Add(new Sword());
            }

            // Add daggers for a 20% chance to drop
            for (int i = 0; i < 20; i++)
            {
                lootTable.Add(new Dagger());
            }

            // Add BattleAxes for a 10% chance to drop
            for (int i = 0; i < 10; i++)
            {
                lootTable.Add(new BattleAxe());
            }

            // Add LongSwords for a 15% chance to drop
            for (int i = 0; i < 15; i++)
            {
                lootTable.Add(new LongSword());
            }


            // Add HealthPotions for a 20% chance to drop 
            for (int i = 0; i < 20; i++)
            {
                lootTable.Add(new HealthPotion());
            }

            // Add GrateHealthPotions for a 15% chance to drop
            for (int i = 0; i < 15; i++)
            {
                lootTable.Add(new GreatHealthPotion());
            }

            // Add UltraHealthPotions for a 5% chance to drop
            for (int i = 0; i < 5; i++)
            {
                lootTable.Add(new UltraHealthPotion());
            }

            return lootTable[random.Next(lootTable.Count)];
        }

        // Function to add items to the inventory
        public void addToInventory(ref string foundItem)
        {
            Items item = randomItem(); // Assing the random item to the item variable
            inventoryList.Add(item);  // Add the random item selected to the inventory list
            foundItem = item.itemName; // Assing the item name to the item found
        }


        // Function to remove items from the inventory
        public void removeFromInventory(Items item)
        {
            inventoryList.Remove(item);
        }

        // Function to check the player's inventory
        public void checkInventory()
        {
            if (inventoryList.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine(GameManager.Player1.playerName + "You currently have:");
                // Foreach loop that runs for each item in the inventory
                foreach (Items item in inventoryList)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{item.itemName}");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("You currently have no items");
                Console.ResetColor();
            }

            
        }

        // Function to add items of the "weapon" type to the weapon list
        public List<Weapons> GetWeapons()
        {
            List<Weapons> weaponList = new List<Weapons>();
            
            //Loop that runs for each item in the inventory
            foreach (Items item in inventoryList)
            {
                if(item is Weapons weapon)
                {
                    weaponList.Add(weapon);
                }

            }
            return weaponList;

        }

        // Function to add items of the "consumable" type to the consumables list
        public List<Consumables> GetConsumables()
        {
            List<Consumables> consumableList = new List<Consumables>();

            //Loop that runs for each item in the inventory
            foreach (Items item in inventoryList)
            {
                if( item is Consumables consumable)
                {
                    consumableList.Add(consumable);
                }
            }
            return consumableList;
        }
    }
}
