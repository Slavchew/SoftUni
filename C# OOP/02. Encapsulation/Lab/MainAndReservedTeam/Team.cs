using System;
using System.Collections.Generic;

namespace MainAndReservedTeam
{
    class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public IReadOnlyCollection<Person> FirstTeam
        {
            get { return this.firstTeam.AsReadOnly(); }
        }

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return this.reserveTeam.AsReadOnly(); }
        }

        public string Name
        {
            get { return this.name; }
        }

        public void AddPlayer(Person player)
        {
            if (player.Age < 40)
            {
                firstTeam.Add(player);
            }
            else
                reserveTeam.Add(player);
        }

        public override string ToString()
        {
            return $"First team has {this.FirstTeam.Count} players." + Environment.NewLine +
                   $"Reserve team has {this.ReserveTeam.Count} players.";
        }
    }
}
