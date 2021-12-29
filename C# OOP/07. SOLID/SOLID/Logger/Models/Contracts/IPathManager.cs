namespace LoggerExercise.Models.Contracts
{
    public interface IPathManager
    {
        // bin/debug
        string CurrentDirectoryPath { get; }

        // bin/debug/logfile.txt
        string CurrentFilePath { get; }

        string GetCurrentPath();

        void EnsureDirectoryAndFileExists();
    }
}
