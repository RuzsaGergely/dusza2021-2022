using System.IO;

namespace Pop_it_GUI
{
    public class Logger
    {
        private string LogFile;
        public Logger(string File_name)
        {
            LogFile = File_name;
        }
        public void LogError(string Message)
        {
            File.AppendAllText(LogFile, $"[Error] {Message}\n\r");
        }
        public void LogDebug(string Message)
        {
            File.AppendAllText(LogFile, $"[Debug] {Message}\n\r");
        }
    }
}
