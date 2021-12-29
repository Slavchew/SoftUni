using MilitaryElite.Enumerations;
using MilitaryElite.Interfaceses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary,
            SoldierCorpEnum soldierCorpEnum, ICollection<IRepair> repairs) 
            : base(id, firstName, lastName, salary, soldierCorpEnum)
        {
            this.Repairs = repairs;
        }

        public ICollection<IRepair> Repairs { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Code Number: {this.SoldierCorpEnum}");
            foreach (var repair in Repairs)
            {
                sb.AppendLine(repair.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
