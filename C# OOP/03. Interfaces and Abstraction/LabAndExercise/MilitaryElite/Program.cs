using MilitaryElite.Interfaceses;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<ISoldier> soldiers = new List<ISoldier>();

            string[] input = Console.ReadLine().Split(" ");
            ISoldier soldier;
            while (input[0] != "End")
            {
                var soldierType = input[0];

                if (soldierType == "Private")
                {
                    var id = int.Parse(input[1]);
                    var firstName = input[2];
                    var lastName = input[3];
                    var salary = decimal.Parse(input[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                    soldiers.Add(soldier);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    var id = int.Parse(input[1]);
                    var firstName = input[2];
                    var lastName = input[3];
                    var salary = decimal.Parse(input[4]);
                    ICollection<IPrivate> privates = new List<IPrivate>();
                    for (int i = 5; i < input.Length; i++)
                    {
                        var privateId = int.Parse(input[i]);
                        foreach (var sol in soldiers)
                        {
                            if (sol.Id == privateId)
                            {
                                privates.Add((IPrivate)sol);
                            }
                        }
                    }
                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                }
                else if (soldierType == "Engineer")
                {
                    var id = int.Parse(input[1]);
                    var firstName = input[2];
                    var lastName = input[3];
                    var salary = decimal.Parse(input[4]);
                    var corp = input[5];
                    if (!IsValidCorp(corp))
                    {
                        return;
                    }
                    ICollection<IRepair> repairs = new List<IRepair>();
                    for (int i = 6; i < input.Length; i += 2)
                    {
                        var rapairPart = input[i];
                        var repairHours = int.Parse(input[i + 1]);
                        var repair = new Repair(rapairPart, repairHours);
                        repairs.Add(repair);
                    }
                    soldier = new Engineer(id, firstName, lastName, salary, corp, repairs );
                }
                else if (soldierType == "Commando")
                {
                    var id = int.Parse(input[1]);
                    var firstName = input[2];
                    var lastName = input[3];
                    var salary = decimal.Parse(input[4]);
                    ICollection<IPrivate> privates = new List<IPrivate>();

                    ICollection<IRepair> repairs = new List<IRepair>();
                    for (int i = 6; i < input.Length; i += 2)
                    {
                        var rapairPart = input[i];
                        var repairHours = int.Parse(input[i + 1]);
                        var repair = new Repair(rapairPart, repairHours);
                        repairs.Add(repair);
                    }

                    soldier = new Commando()
                }
                else if (soldierType == "Spy")
                {
                    var id = int.Parse(input[1]);
                    var firstName = input[2];
                    var lastName = input[3];
                    var codeNumber = int.Parse(input[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }


                input = Console.ReadLine().Split(" ");
            }

            PrintResult(soldiers);
        }

        private static void PrintResult(ICollection<ISoldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private static bool IsValidCorp(string corp)
        {
            if (corp != "Marines" && corp != "Airforces")
            {
                return false;
            }
            return true;
        }
    }
}
