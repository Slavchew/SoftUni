using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
            this.Pokemons = new List<Pokemon>();
            this.Parents = new List<Parent>();
            this.Children = new List<Child>();
        }

        public string Name { get; set; }
        public Company Company { get; set; }
        public List<Pokemon> Pokemons { get; set; }
        public List<Parent> Parents { get; set; }
        public List<Child> Children { get; set; }
        public Car Car { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Name).AppendLine("Company:");
            if (this.Company != null)
            {
                sb.AppendLine(this.Company.ToString());
            }

            sb.AppendLine("Car:");
            if (this.Car != null)
            {
                sb.AppendLine(this.Car.ToString());
            }

            sb.AppendLine("Pokemon:");
            if (this.Pokemons.Count != 0)
            {
                foreach (Pokemon pokemon in this.Pokemons)
                {
                    sb.AppendLine(pokemon.ToString());
                }
            }

            sb.AppendLine("Parents:");
            if (this.Parents.Count != 0)
            {
                foreach (Parent parent in this.Parents)
                {
                    sb.AppendLine(parent.ToString());
                }
            }

            sb.AppendLine("Children:");
            if (this.Children.Count != 0)
            {
                foreach (Child child in this.Children)
                {
                    sb.AppendLine(child.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
