

namespace GameDataParser_Assignment.logging
{
    public class Logger
    {
        private readonly string _logFilename;
        public Logger(string logFilename)
        {
            _logFilename = logFilename;
        }
        public void Log(Exception ex)
        {
            var entry =
                $@" [{DateTime.Now}] 
                    Exception message: {ex.Message}
                    Stack Trace: {ex.StackTrace}
                ";
            File.AppendAllText(_logFilename, entry);
        }
    }
}
