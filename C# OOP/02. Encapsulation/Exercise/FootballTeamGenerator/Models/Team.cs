using System;
using System.Linq;
using System.Collections.Generic;

using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Models
{
    class Team
    {
        private string name;
        private readonly ICollection<Player> players;

        private Team()
        {
            this.players = new List<Player>();
        }
        public Team(string name)
                : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameExcMsg);
                }

                this.name = value;
            }
        }

        public int Rating => this.players.Count > 0 ? (int)Math.Round(this.players.Average(p => p.OverallSkill)) : 0;

        public void AddPleyer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = players.FirstOrDefault(p => p.Name == playerName);

            if(playerToRemove == null)
            {
                throw new InvalidOperationException(String.Format(GlobalConstants.MissingPlayerExcMsg, playerName, this.name));
            }

            this.players.Remove(playerToRemove);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
