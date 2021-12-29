using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hideout
{
    class Hideout
    {
        static void Main()
        {
            string map = Console.ReadLine();
            string[] clue = Console.ReadLine().Split(' ');

            char evidence = char.Parse(clue[0]);
            int minCount = int.Parse(clue[1]);
            int startIndexOfEvidence = -1;
            int count = 0;
            int longestSeq = 0;

            while (true)
            {
                for (int index = 0; index < map.Length; index++)
                {
                    if (map[index] == evidence)
                    {
                        count++;
                    }
                    else
                    {
                        if (count > longestSeq)
                        {
                            startIndexOfEvidence = index - count;
                            longestSeq = count;
                        }
                        count = 0;
                    }
                }
                if (count > longestSeq)
                {
                    startIndexOfEvidence = map.Length - count;
                    longestSeq = count;
                }
                if (longestSeq >= minCount)
                {
                    Console.WriteLine($"Hideout found at index {startIndexOfEvidence} and it is with size {longestSeq}!");
                    break;
                }
                clue = Console.ReadLine().Split(' ');
                evidence = char.Parse(clue[0]);
                minCount = int.Parse(clue[1]);
            }
        }
    }
}
