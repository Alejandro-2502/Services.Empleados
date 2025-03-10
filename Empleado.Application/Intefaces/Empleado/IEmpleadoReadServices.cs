using Empleado.Application.Generics;
using Empleado.Application.Responses.Empleado;

namespace Empleado.Application.Intefaces.Empleado
{
    public interface IEmpleadoReadServices
    {
        Task<Responses<EmpleadoResponse>> GetById(int id);
        Task<Responses<List<EmpleadoResponse>>> GetAll();
        Task<Responses<List<EmpleadoResponse>>> GetByEdadMayorIgual(int edad);
        Task<Responses<List<EmpleadoResponse>>> GetEmpleadosActive(bool active);
    }
}
