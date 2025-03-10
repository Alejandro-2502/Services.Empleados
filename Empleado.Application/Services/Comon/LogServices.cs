using Empleado.Application.IComon;

namespace Empleado.Application.Services.Comon
{
    public class LogServices : ILogServices
    {
        private readonly string _logFilePath;

        public LogServices(string logFilePath)
        {
            _logFilePath = logFilePath;

            if (!File.Exists(_logFilePath))
            {
                File.Create(_logFilePath).Dispose();
            }
        }

        public void Log(string message)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }

        public void LogError(string message)
        {
            string logMessage = $"ERROR: {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }

        public void LogWarning(string message)
        {
            string logMessage = $"WARNING: {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }
    }
}
