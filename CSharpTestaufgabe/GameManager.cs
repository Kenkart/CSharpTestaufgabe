using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTestaufgabe
{
    class GameManager
    {
        private int diskCount;
        private int steps;

        private List<Stack<Disk>> rods;

        public GameManager(int diskCount)
        {
            this.diskCount = diskCount;

            // Initialize 3 rods
            rods = new List<Stack<Disk>>();
            for (int i = 0; i < 3; i++)
            {
                rods.Add(new Stack<Disk>());
            }

            // Initialize disks in first rod
            for (int i = diskCount; i > 0; i--)
            {
                rods[0].Push(new Disk(i));
            }
        }

        public void Print()
        {
            Console.WriteLine("A B C");
            for (int i = 0; i < diskCount; i++)
            {
                for (int j = 0; j < rods.Count; j++)
                {
                    if (rods[j].Count + i >= diskCount)
                    {
                        Console.Write(rods[j].ElementAt(i - (diskCount - rods[j].Count)) + " ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine("");
            }
        }

        public void MoveDisk(char from, char to)
        {
            from = Char.ToLower(from);
            to = Char.ToLower(to);

            int x = from - 'a';
            int y = to - 'a';

            // Check rod is valid
            if (x < 0 || x > 2 || y < 0 || y > 2)
            {
                Console.WriteLine("Invalid rod!");
                return;
            }

            if (x == y)
            {
                Console.WriteLine("No changes, same rod!");
                return;
            }

            // Check rod is empty
            if (rods[x].Count == 0)
            {
                Console.WriteLine("Rod " + Convert.ToChar(x + 'a') + " has no disks!");
                return;
            }

            // If destination is not empty and check disk size
            if (rods[y].Count != 0 && rods[x].Peek().size > rods[y].Peek().size)
            {
                Console.WriteLine("Disk is bigger to be put on other disk!");
                return;
            }

            Disk d = rods[x].Pop();
            rods[y].Push(d);

            steps++;
        }

        public bool IsGameFinish()
        {
            return rods[2].Count == diskCount;
        }

        public void ShowSteps()
        {
            Console.WriteLine("Steps: " + steps);
            Console.WriteLine("Optimal steps: " + (Math.Pow(2, diskCount) - 1));
        }

    }
}
