using System;

using LoggerExercise.Models.Enumerations;

namespace LoggerExercise.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}