using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Player
    {
        public string Name { get; set; }

        public Player(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
