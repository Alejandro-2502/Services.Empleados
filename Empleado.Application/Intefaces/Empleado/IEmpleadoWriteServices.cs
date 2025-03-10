using Empleado.Application.Generics;
using Empleado.Application.Requests.Empleado;
using Empleado.Application.Responses.Empleado;

namespace Empleado.Application.Intefaces.Empleado
{
    public interface IEmpleadoWriteServices
    {
        Task<Responses<EmpleadoResponse>> Insert(EmpleadoRequest request);
        Task<Responses<EmpleadoResponse>> Update(EmpleadoRequest request);
        Task<Responses<EmpleadoResponse>> Delete(int id);
        Task<Responses<EmpleadoResponse>> DeleteLogic(int id);
    }
}
