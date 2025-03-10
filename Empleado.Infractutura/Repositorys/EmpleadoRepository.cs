using Empleado.Domain.Interfaces;
using Empleado.Entity.Entitys;
using Empleado.Infractutura.Context;
using Empleado.Infractutura.Repositorys;

namespace Empleado.Infractutura.Repository
{
    public class EmpleadoRepository : Repository<EmpleadoEntity>, IEmpleadoRepository
    {
        private readonly DataContext _dataContext;

        public EmpleadoRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

    }
}
    