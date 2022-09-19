using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTestaufgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            int diskCountInt;

            Console.WriteLine("Welcome to the game!");
            Console.WriteLine("You need to move all the disks from rod A to rod C");
            Console.WriteLine("---------------------------------");

            // Input disk count
            while (true)
            {
                Console.WriteLine("How many disks?");
                string diskCountString = Console.ReadLine();

                if (Int32.TryParse(diskCountString, out diskCountInt))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Input must be a number!");
                }
            }


            GameManager gameManager = new GameManager(diskCountInt);

            // Gameplay
            while (!gameManager.IsGameFinish())
            {
                Console.WriteLine("--------------------------------------");
                gameManager.Print();

                Console.WriteLine("Select from which rod to move the disk? (a/b/c)");
                char from = Console.ReadLine()[0];
                Console.WriteLine("Select destination rod to move the disk? (a/b/c)");
                char to = Console.ReadLine()[0];

                gameManager.MoveDisk(from, to);
            }

            gameManager.Print();
            Console.WriteLine("Finish!");
            gameManager.ShowSteps();
        }
    }
}
