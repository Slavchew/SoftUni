using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enumerations;
using MilitaryElite.Interfaceses;

namespace MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, SoldierCorpEnum soldierCorpEnum) 
            : base(id, firstName, lastName, salary)
        {
            this.SoldierCorpEnum = soldierCorpEnum;
        }

        public SoldierCorpEnum SoldierCorpEnum { get; }
    }
}
