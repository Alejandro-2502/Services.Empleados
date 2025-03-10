using Empleado.Domain.Interfaces;
using Empleado.Infractutura.Context;
using Empleado.Infractutura.Repository;

namespace Empleado.Infractutura.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private IEmpleadoRepository _empleadoRepository;
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEmpleadoRepository empleadoRepository => _empleadoRepository =
                _empleadoRepository ?? new EmpleadoRepository(_dataContext);
        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}
