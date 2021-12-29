using System;

using LoggerExercise.Common;
using LoggerExercise.IOManagment;
using LoggerExercise.IOManagment.Contracts;
using LoggerExercise.Models.Contracts;
using LoggerExercise.Models.Enumerations;

namespace LoggerExercise.Models.Appenders
{
    public class ConsoleAppender : Appender
    {
        private readonly IWriter writer;
        public ConsoleAppender(ILayout layout, Level level)
            : base(layout, level)
        {
            this.writer = new ConsoleWriter();
        }

        public override void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedString = String.Format(format, dateTime.ToString(GlobalConstants.DateTimeFormat), level.ToString(), message);

            this.writer.WriteLine(formattedString);
            this.messagesAppended++;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
