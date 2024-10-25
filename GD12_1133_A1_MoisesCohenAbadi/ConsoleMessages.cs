using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_MoisesCohenAbadi
{
    public class ConsoleMessages
    {
        public void Intro()
        {
            Console.WriteLine(@" ___       __   _______   ___       ________  ________  _____ ______   _______                   
|\  \     |\  \|\  ___ \ |\  \     |\   ____\|\   __  \|\   _ \  _   \|\  ___ \                  
\ \  \    \ \  \ \   __/|\ \  \    \ \  \___|\ \  \|\  \ \  \\\__\ \  \ \   __/|                 
 \ \  \  __\ \  \ \  \_|/_\ \  \    \ \  \    \ \  \\\  \ \  \\|__| \  \ \  \_|/__               
  \ \  \|\__\_\  \ \  \_|\ \ \  \____\ \  \____\ \  \\\  \ \  \    \ \  \ \  \_|\ \              
   \ \____________\ \_______\ \_______\ \_______\ \_______\ \__\    \ \__\ \_______\             
    \|____________|\|_______|\|_______|\|_______|\|_______|\|__|     \|__|\|_______|             
                                                                                                 
                                                                                                 
                                                                                                 
 _________  ________          _________  ___  ___  _______                                       
|\___   ___\\   __  \        |\___   ___\\  \|\  \|\  ___ \                                      
\|___ \  \_\ \  \|\  \       \|___ \  \_\ \  \\\  \ \   __/|                                     
     \ \  \ \ \  \\\  \           \ \  \ \ \   __  \ \  \_|/__                                   
      \ \  \ \ \  \\\  \           \ \  \ \ \  \ \  \ \  \_|\ \                                  
       \ \__\ \ \_______\           \ \__\ \ \__\ \__\ \_______\                                 
        \|__|  \|_______|            \|__|  \|__|\|__|\|_______|                                 
                                                                                                 
                                                                                                 
                                                                                                 
 _____ ______   ___  ________   ________  _________  ________  ___  ___  ________  ________      
|\   _ \  _   \|\  \|\   ___  \|\   __  \|\___   ___\\   __  \|\  \|\  \|\   __  \|\   ____\     
\ \  \\\__\ \  \ \  \ \  \\ \  \ \  \|\  \|___ \  \_\ \  \|\  \ \  \\\  \ \  \|\  \ \  \___|_    
 \ \  \\|__| \  \ \  \ \  \\ \  \ \  \\\  \   \ \  \ \ \   __  \ \  \\\  \ \   _  _\ \_____  \   
  \ \  \    \ \  \ \  \ \  \\ \  \ \  \\\  \   \ \  \ \ \  \ \  \ \  \\\  \ \  \\  \\|____|\  \  
   \ \__\    \ \__\ \__\ \__\\ \__\ \_______\   \ \__\ \ \__\ \__\ \_______\ \__\\ _\ ____\_\  \ 
    \|__|     \|__|\|__|\|__| \|__|\|_______|    \|__|  \|__|\|__|\|_______|\|__|\|__|\_________\
                                                                                     \|_________|
                                                                                                 
                                                                                                 
 ___       ________  ________      ___    ___ ________  ___  ________   _________  ___  ___      
|\  \     |\   __  \|\   __  \    |\  \  /  /|\   __  \|\  \|\   ___  \|\___   ___\\  \|\  \     
\ \  \    \ \  \|\  \ \  \|\ /_   \ \  \/  / | \  \|\  \ \  \ \  \\ \  \|___ \  \_\ \  \\\  \    
 \ \  \    \ \   __  \ \   __  \   \ \    / / \ \   _  _\ \  \ \  \\ \  \   \ \  \ \ \   __  \   
  \ \  \____\ \  \ \  \ \  \|\  \   \/  /  /   \ \  \\  \\ \  \ \  \\ \  \   \ \  \ \ \  \ \  \  
   \ \_______\ \__\ \__\ \_______\__/  / /      \ \__\\ _\\ \__\ \__\\ \__\   \ \__\ \ \__\ \__\ 
    \|_______|\|__|\|__|\|_______|\___/ /        \|__|\|__|\|__|\|__| \|__|    \|__|  \|__|\|__| 
                                 \|___|/                                                         ");
        }

        public void PlayerName()
        {
            Console.WriteLine("What is your name?");
            GameManager.Player1.playerName = Console.ReadLine();

        }

        public void Description()
        {
            Console.WriteLine("Hello " + GameManager.Player1.playerName + " and wlecome to the game The Minotaur's Labyritnth");
            Console.WriteLine("In this game you will explore a dungeon");
            Console.WriteLine("You will gather loot and will fight monsters");
            Console.WriteLine("When entering a room you can search for treasure");
            Console.WriteLine("If there are monsters you can fight them and they will drop some loot");
            Console.WriteLine("Some rooms will yield bigger treasure than others");
            Console.WriteLine("Try to find and defeat The Minotaur, but be wary for he is a Mighty foe");
            Console.WriteLine("Good luck Adventurer");
        }

        public void End()
        {
            Console.WriteLine("Goodbye");
            Console.WriteLine("Thanks for playing");
            Console.WriteLine("KPU ENTA 1133 Moises Cohen Abadi 10/18/2024");

        }
    }
}
