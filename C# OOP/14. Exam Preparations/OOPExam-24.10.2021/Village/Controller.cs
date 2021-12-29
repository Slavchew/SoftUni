using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Village
{
    public class Controller
    {
        private readonly List<Village> villages;
        private readonly List<Rebel> rebels;
        private int attacks = 0;

        public Controller()
        {
            this.villages = new List<Village>();
            this.rebels = new List<Rebel>();
        }
        public string ProceseVillageCommand(List<string> args)
        {
            string name = args[0];
            string location = args[1];

            Village village = new Village(name, location);

            this.villages.Add(village);

            return $"Created Village {name}!";
        }
        public string ProcessSettleCommand(List<string> args)
        {
            string name = args[0];
            int age = int.Parse(args[1]);
            int productivity = int.Parse(args[2]);
            string villageName = args[3];

            Peasant peasant = new Peasant(name, age, productivity);

            this.villages.FirstOrDefault(x => x.Name == villageName).AddPeasant(peasant);

            return $"Settled Peasant {name} in Village {villageName}!";
        }

        public string ProcessRebelCommand(List<string> args)
        {
            string name = args[0];
            int age = int.Parse(args[1]);
            int harm = int.Parse(args[2]);

            Rebel rebel = new Rebel(name, age, harm);

            this.rebels.Add(rebel);

            return $"Rebel {name} joined the gang!";
        }

        public string ProcessDayCommand(List<string> args)
        {
            string villageName = args[0];

            var dailyResource = this.villages.FirstOrDefault(x => x.Name == villageName).PassDay();

            return $"Village {villageName} resource increased with {dailyResource}!";
        }

        public string ProcessAttackCommand(List<string> args)
        {
            int rebelCount = int.Parse(args[0]);
            string villageName = args[1];

            if (this.rebels.Count != 0)
            {
                var harmSum = 0;
                if (this.rebels.Count >= rebelCount)
                {
                    for (int i = 0; i < rebelCount; i++)
                    {
                        harmSum += this.rebels[i].Harm;
                    }
                }
                else
                {
                    foreach (var rebel in this.rebels)
                    {
                        harmSum += rebel.Harm;
                    }
                }

                Village village = this.villages.FirstOrDefault(x => x.Name == villageName);
                village.Resource -= harmSum;

                village.KillPeasants(rebelCount / 2);

                this.attacks++;

                return $"Village {villageName} lost {harmSum} resources and {rebelCount / 2} peasants!";
            }

            return $"No rebels to perform raid...";
        }
        public string ProcessInfoCommand(List<string> args)
        {
            string side = args[0];

            if (side == "Rebel")
            {
                if (this.rebels.Count != 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Rebels: ");
                    foreach (var rebel in this.rebels)
                    {
                        sb.AppendLine(rebel.ToString());
                    }

                    return sb.ToString().TrimEnd();
                }
                else
                {
                    return "No Rebels";
                }
            }
            else if (side == "Village")
            {
                if (this.villages.Count != 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Villages: ");
                    foreach (var village in this.villages)
                    {
                        sb.AppendLine(village.ToString());
                    }

                    return sb.ToString().TrimEnd();
                }
                else
                {
                    return "No Villages";
                }
            }

            return "";
        }

        public string ProcessEndCommand()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Villages: {this.villages.Count}");
            sb.AppendLine($"Rebels: {this.rebels.Count}");
            sb.AppendLine($"Attacks on Villages: {this.attacks}");

            return sb.ToString().TrimEnd();
        }
    }
}
