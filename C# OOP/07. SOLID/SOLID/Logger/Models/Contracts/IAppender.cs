using LoggerExercise.Models.Enumerations;

namespace LoggerExercise.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        void Append(IError error);
    }
}
