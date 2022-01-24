using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var trainerInfo = Console.ReadLine().Split(" ");
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            while (trainerInfo[0] != "Tournament")
            {
                var trainerName = trainerInfo[0];
                var pokemonName = trainerInfo[1];
                var pokemonElement = trainerInfo[2];
                var pokemonHp = int.Parse(trainerInfo[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHp);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = new Trainer(trainerName);

                }
                trainers[trainerName].Pokemons.Add(pokemon);

                trainerInfo = Console.ReadLine().Split(" ");
            }

            var type = Console.ReadLine();
            while (type != "End")
            {
                foreach (var trainer in trainers)
                {
                    foreach (var pokemon in trainer.Value.Pokemons)
                    {
                        if (pokemon.Element == type)
                        {
                            trainer.Value.Badges++;
                            break;
                        }
                        else
                        {
                            pokemon.Health -= 10;
                        }
                    }
                }
                type = Console.ReadLine();
            }

            foreach (var trainer in trainers)
            {
                for (int i = 0; i < trainer.Value.Pokemons.Count; i++)
                {
                    if (trainer.Value.Pokemons[i].Health <= 0)
                    {
                        trainer.Value.Pokemons.RemoveAt(i);
                        i--;
                    }
                }
            }

            var sortedTrainers = trainers.OrderByDescending(x => x.Value.Badges);
            foreach (var trainer in sortedTrainers)
            {
                Console.WriteLine(trainer.Value.ToString());
            }
            
        }
    }
}
