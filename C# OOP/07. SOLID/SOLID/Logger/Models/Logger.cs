using System.Text;
using System.Collections.Generic;

using LoggerExercise.Models.Contracts;

namespace LoggerExercise.Models
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }
        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            foreach (var appender in this.appenders)
            {
                if (error.Level >= appender.Level)
                {
                    appender.Append(error);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Logger info");

            foreach (IAppender appender in this.appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
