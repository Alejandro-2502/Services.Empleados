using Empleado.Application.Requests.Empleado;

namespace Empleado.Application.Intefaces.Validator
{
    public interface IValidationsServices
    {
        Task<List<string>> Validator(EmpleadoRequest empleadoRequest);
    }
}
