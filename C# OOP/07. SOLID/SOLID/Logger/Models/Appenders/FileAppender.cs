using LoggerExercise.IOManagment;
using LoggerExercise.IOManagment.Contracts;
using LoggerExercise.Models.Contracts;
using LoggerExercise.Models.Enumerations;

namespace LoggerExercise.Models.Appenders
{
    public class FileAppender : Appender
    {
        private readonly IWriter writer;
        public FileAppender(ILayout layout, Level level, IFile file)
            : base(layout, level)
        {
            this.File = file;

            this.writer = new FileWriter(this.File.Path);
        }

        public IFile File { get; }

        public override void Append(IError error)
        {
            string formattedMessage = this.File.Write(this.Layout, error);

            this.writer.WriteLine(formattedMessage);
            this.messagesAppended++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size {this.File.Size}";
        }
    }
}
