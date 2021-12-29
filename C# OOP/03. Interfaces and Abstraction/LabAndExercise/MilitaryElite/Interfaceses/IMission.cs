using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enumerations;

namespace MilitaryElite.Interfaceses
{
    public interface IMission
    {
        string CodeName { get; }

        MissionStateEnum MissionStateEnum { get; }

        void CompleteMission(string missionName);
    }
}
