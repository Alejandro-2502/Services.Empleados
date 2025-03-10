using Empleado.Application.Generics;
using Empleado.Application.Intefaces.Empleado;
using Empleado.Application.Responses.Empleado;
using Microsoft.AspNetCore.Mvc;

namespace ServicioEmpleado.Controllers.v1
{
    public class EmpleadoReadController : ControllerBase
    {
        private readonly IEmpleadoReadServices _empleadoReadServices;
        private readonly ResponseHttp _responseHttp;

        public EmpleadoReadController(IEmpleadoReadServices empleadoReadServices, ResponseHttp responseHttp)
        {
            _empleadoReadServices = empleadoReadServices;
            _responseHttp = responseHttp;
        }

        [HttpGet("ById{id}")]
        [ProducesResponseType(typeof(Responses<EmpleadoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Responses<EmpleadoResponse>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _empleadoReadServices.GetById(id);
            return await _responseHttp.GetResponseHttp(response);
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(Responses<List<EmpleadoResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Responses<EmpleadoResponse>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _empleadoReadServices.GetAll();
            return await _responseHttp.GetResponseHttp(response);
        }

        [HttpGet("ByEdadMayorIgual{edad}")]
        [ProducesResponseType(typeof(Responses<EmpleadoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Responses<EmpleadoResponse>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByEdadMayorIgual(int edad)
        {
            var response = await _empleadoReadServices.GetByEdadMayorIgual(edad);
            return await _responseHttp.GetResponseHttp(response);
        }

        [HttpGet("Activos-NoActivos")]
        [ProducesResponseType(typeof(Responses<List<EmpleadoResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Responses<EmpleadoResponse>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEmpleadosActive(bool active)
        {
            var response = await _empleadoReadServices.GetEmpleadosActive(active);
            return await _responseHttp.GetResponseHttp(response);
        }
    }
}
