using LoggerExercise.Models.Contracts;
using LoggerExercise.Models.Enumerations;

namespace LoggerExercise.Models.Appenders
{
    public abstract class Appender : IAppender
    {
        protected int messagesAppended;
        protected Appender(ILayout layout, Level level)
        {
            Layout = layout;
            Level = level;
        }

        public ILayout Layout { get; }

        public Level Level { get; }

        public abstract void Append(IError error);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}";
        }
    }
}
