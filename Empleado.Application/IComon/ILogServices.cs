namespace Empleado.Application.IComon
{
    public interface ILogServices
    {
        void Log(string message);
        void LogError(string message);
        void LogWarning(string message);
    }
}
