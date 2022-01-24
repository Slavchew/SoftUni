using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Count}";
        }
    }
}
