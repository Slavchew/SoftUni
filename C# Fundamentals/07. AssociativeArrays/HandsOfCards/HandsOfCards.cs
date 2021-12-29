using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOfCards
{
    class HandsOfCards
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(':').ToArray();
            var players = new Dictionary<string, List<string>>();
            while (input[0] != "JOKER")
            {
                var currentDraw = input[1]
                    .Split(new char[] { ' ', ',' })
                    .Where(x => x != "")
                    .Distinct()
                    .ToList();

                if (players.ContainsKey(input[0]))
                    players[input[0]] =
                        players[input[0]]
                        .Concat(currentDraw)
                        .Distinct()
                        .ToList();
                else
                    players[input[0]] = currentDraw.Distinct().ToList();

                input = Console.ReadLine().Split(':').ToArray();
            }

            var playerPoints = new Dictionary<string, int>();
            var totalPoints = 0;
            foreach (var person in players)
            {
                totalPoints = 0;
                for (int i = 0; i < person.Value.Count; i++)
                {
                    var currentCard = person.Value[i];
                    var cardType = currentCard.Last();
                    var multiplier = 0;

                    switch (cardType)
                    {
                        case 'C': multiplier = 1; break;
                        case 'D': multiplier = 2; break;
                        case 'H': multiplier = 3; break;
                        case 'S': multiplier = 4; break;
                    }
                    var powerString = currentCard.Substring(0, currentCard.Length - 1);
                    int power = 0;
                    switch (powerString)
                    {
                        case "J": power = 11; break;
                        case "Q": power = 12; break;
                        case "K": power = 13; break;
                        case "A": power = 14; break;
                        default: power = int.Parse(powerString); break;
                    }
                    totalPoints += power * multiplier;
                }

                playerPoints[person.Key] = totalPoints;
            }

            foreach (var person in playerPoints)
            {
                Console.WriteLine("{0}: {1}",person.Key,person.Value);
            }
        }
    }
}
