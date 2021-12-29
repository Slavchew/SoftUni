using MilitaryElite.Enumerations;
using MilitaryElite.Interfaceses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionStateEnum missionStateEnum)
        {
            this.CodeName = codeName;
            this.MissionStateEnum = missionStateEnum;
        }

        public string CodeName { get; }

        public MissionStateEnum MissionStateEnum { get; }

        public void CompleteMission(string missionName)
        {
            
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.MissionStateEnum}";
        }
    }
}
