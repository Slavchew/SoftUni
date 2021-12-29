using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Village
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Controller controller = new Controller();
            StringBuilder stringBuilder = new StringBuilder();
            bool isRunning = true;

            while (isRunning)
            {
                List<string> lineArgs = Console.ReadLine()
                   .Split(" ")
                   .ToList();

                string command = lineArgs[0];

                lineArgs = lineArgs
                    .Skip(1)
                    .ToList();
                try
                {
                    switch (command)
                    {
                        case "Village":
                            stringBuilder.AppendLine(controller.ProceseVillageCommand(lineArgs));
                            break;
                        case "Settle":
                            stringBuilder.AppendLine(controller.ProcessSettleCommand(lineArgs));
                            break;
                        case "Rebel":
                            stringBuilder.AppendLine(controller.ProcessRebelCommand(lineArgs));
                            break;
                        case "Day":
                            stringBuilder.AppendLine(controller.ProcessDayCommand(lineArgs));
                            break;
                        case "Attack":
                            stringBuilder.AppendLine(controller.ProcessAttackCommand(lineArgs));
                            break;
                        case "Info":
                            stringBuilder.AppendLine(controller.ProcessInfoCommand(lineArgs));
                            break;
                        case "End":
                            stringBuilder.AppendLine(controller.ProcessEndCommand());
                            isRunning = false;
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    stringBuilder.AppendLine(ex.Message);
                }

            }

            Console.WriteLine(stringBuilder.ToString().Trim());
        }
    }
}
