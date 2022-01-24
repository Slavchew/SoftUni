using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Pokemon
    {
        public Pokemon(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Type}";
        }
    }
}
