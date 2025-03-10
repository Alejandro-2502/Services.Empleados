namespace Empleado.Domain.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        public Task<int> SaveChangesAsync();
        IEmpleadoRepository  empleadoRepository  { get; }
    }
}   