using System;

using LoggerExercise.Models.Contracts;
using LoggerExercise.Models.Enumerations;

namespace LoggerExercise.Models.Errors
{
    public class Error : IError
    {
        public Error(DateTime dateTime, string message, Level level)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public Level Level { get; }
    }
}
