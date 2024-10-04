using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_MoisesCohenAbadi
{
    internal class CPU
    {
        public int Score = 0;
        public int CurrentRoll = 0;
        public List<int> CPUDicePool = new List<int> { 4, 6, 8, 10, 12, 20, 100 };


        public void AvailableCPUDice()
        {
            CPUDicePool = new List<int> { 4, 6, 8, 10, 12, 20, 100 };
        }

        public void CPUTurn()
        {
            Console.WriteLine("My turn, whish me luck!");
            Random DieSelection = new Random();
            int SelectedDie = DieSelection.Next(CPUDicePool.Count);
            int DiceRolled = CPUDicePool[SelectedDie];
            Console.WriteLine("Rolling D" + CPUDicePool[SelectedDie].ToString());
            CPUDicePool.RemoveAt(SelectedDie);

            CurrentRoll = DiceRoller.RollDie(SelectedDie);
            Score += CurrentRoll;
        }

        public void CPUStats ()
        {
            Console.WriteLine("My Total Score is:" + Score);
        }
    }

    

}
