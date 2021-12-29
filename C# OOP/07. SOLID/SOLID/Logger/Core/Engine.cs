using System;
using System.Linq;
using System.Globalization;

using LoggerExercise.Common;
using LoggerExercise.Core.Contracts;
using LoggerExercise.IOManagment.Contracts;
using LoggerExercise.Models.Contracts;
using LoggerExercise.Models.Enumerations;
using LoggerExercise.Models.Errors;

namespace LoggerExercise.Core
{
    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ILogger logger, IReader reader, IWriter writer)
        {
            this.logger = logger;
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "END")
            {
                string[] errorArgs = command.Split("|").ToArray();

                string levelStr = errorArgs[0];
                string dateTimeStr = errorArgs[1];
                string message = errorArgs[2];

                bool isLevelValid = Enum.TryParse(typeof(Level), levelStr, true, out object levelOBj);

                if (!isLevelValid)
                {
                    this.writer.WriteLine(GlobalConstants.InvalidLevelType);
                    continue;
                }

                Level level = (Level)levelOBj;

                bool isDateTimeValid = DateTime.TryParseExact
                    (dateTimeStr, GlobalConstants.DateTimeFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime dateTime);

                if (!isDateTimeValid)
                {
                    this.writer.WriteLine(GlobalConstants.InvalidDateTimeFormat);
                    continue;
                }

                IError error = new Error(dateTime, message, level);

                this.logger.Log(error);
            }

            this.writer.Write(this.logger.ToString());
        }
    }
}
