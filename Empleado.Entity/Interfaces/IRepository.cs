namespace Empleado.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteLogicAsync(int id, bool isActive);
        Task<List<T>> GetByEdadMayotIgual(int edad);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<List<T>> GetEmpleadosActive(bool activo);
    }
}
