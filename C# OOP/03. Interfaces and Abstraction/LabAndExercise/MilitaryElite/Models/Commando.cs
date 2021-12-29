using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enumerations;
using MilitaryElite.Interfaceses;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, 
            SoldierCorpEnum soldierCorpEnum, ICollection<IMission> missions)
            : base(id, firstName, lastName, salary, soldierCorpEnum)
        {
            this.Missions = missions;
        }

        public ICollection<IMission> Missions { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Code Number: {this.SoldierCorpEnum}");
            foreach (var mission in Missions)
            {
                sb.AppendLine(mission.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
