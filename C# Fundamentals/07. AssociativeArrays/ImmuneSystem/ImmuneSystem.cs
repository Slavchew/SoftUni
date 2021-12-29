using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmuneSystem
{
    class ImmuneSystem
    {
        static void Main(string[] args)
        {
            int initialHealth = int.Parse(Console.ReadLine());
            int health = initialHealth;
            int remainingHealth = 0;
            var dict = new Dictionary<string, int>();
            string virus = Console.ReadLine();
            while (virus != "end")
            {
                var virusPower = 0;
                var virusTime = 0;
                foreach (var letter in virus)
                {
                    virusPower += (int)letter;
                }

                if (dict.ContainsKey(virus))
                {
                    virusTime = (dict[virus] * virus.Length) / 3;
                }
                else
                {
                    dict[virus] = virusPower / 3; 
                    virusTime = dict[virus] * virus.Length;
                }
                remainingHealth = health - virusTime;

                Console.WriteLine($"Virus {virus}: {dict[virus]} => {virusTime} seconds");

                if (virusTime > health)
                {
                    Console.WriteLine("Immune System Defeated.");
                    return;
                }

                var min = virusTime / 60;
                var sec = virusTime % 60;
                if (min >= 1)
                {
                    Console.WriteLine($"{virus} defeated in {min}m {sec}s.");
                }
                else
                {
                    Console.WriteLine($"{virus} defeated in {sec}s.");
                }
                Console.WriteLine($"Remaining health: {remainingHealth}");

                health = (int)((remainingHealth) * 1.2);
                if (health > initialHealth) health = initialHealth;

                virus = Console.ReadLine();
            }

            Console.WriteLine($"Final Health: {health}");
        }
    }
}
