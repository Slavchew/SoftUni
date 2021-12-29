using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Village
{
    public class Village
    {
        private string name;
        private string location;
        private List<Peasant> peasants;

        public Village(string name, string location)
        {
            this.peasants = new List<Peasant>();

            this.Name = name;
            this.Location = location;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value.Length < 2 || value.Length > 40)
                {
                    throw new ArgumentException("Name should be between 2 and 40 characters!");
                }
                this.name = value;
            }

        }

        public string Location
        {
            get { return this.location; }
            private set
            {
                if (value.Length < 3 || value.Length > 45)
                {
                    throw new ArgumentException("Location should be between 3 and 45 characters!");
                }
                this.location = value;
            }

        }

        public int Resource { get; set; }


        public void AddPeasant(Peasant peasant)
        {
            this.peasants.Add(peasant);
        }

        public int PassDay()
        {
            var productivity = 0;

            foreach (var peasant in this.peasants)
            {
                productivity += peasant.Productivity;
            }

            this.Resource += productivity;

            return productivity;
        }

        public List<Peasant> KillPeasants(int count)
        {
            if (count <= this.peasants.Count)
            {
                var peasantsToKill = this.peasants.Take(count).ToList();

                for (int i = 0; i < count; i++)
                {
                    this.peasants.RemoveAt(0);
                }

                return peasantsToKill;
            }
            else
            {
                var peasantsToKill = this.peasants.Take(this.peasants.Count).ToList();

                this.peasants.Clear();

                return peasantsToKill;

            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Village - {Name} ({Location})");
            sb.AppendLine($"Resources - {Resource}");
            sb.AppendLine($"Peasants - ({this.peasants.Count})");
            foreach (var peasant in this.peasants)
            {
                sb.AppendLine(peasant.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
