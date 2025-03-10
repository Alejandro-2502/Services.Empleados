using Empleado.Application.Generics;
using Empleado.Application.Intefaces.Empleado;
using Empleado.Application.Requests.Empleado;
using Empleado.Application.Responses.Empleado;
using Microsoft.AspNetCore.Mvc;

namespace ServicioEmpleado.Controllers.v1
{
    [ApiController]
    [Route("api/empleado")]
    [ApiVersion("1")]
    
    
    public class EmpleadoWriteController : ControllerBase
    {
        private readonly IEmpleadoWriteServices _empleadoWriteServices;
        private readonly ResponseHttp _responseHttp;

        public EmpleadoWriteController(IEmpleadoWriteServices empleadoWriteServices, ResponseHttp responseHttp)
        {
            _empleadoWriteServices = empleadoWriteServices;
            _responseHttp = responseHttp;
        }

        [HttpPost()]
        [ProducesResponseType(typeof(Responses<EmpleadoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Responses<EmpleadoResponse>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] EmpleadoRequest empleadoRequest)
        {
            var response = await _empleadoWriteServices.Insert(empleadoRequest);
            return await _responseHttp.GetResponseHttp(response);
        }

        [HttpPut()]
        [ProducesResponseType(typeof(Responses<EmpleadoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Responses<EmpleadoResponse>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] EmpleadoRequest empleadoRequest)
        {
            var response = await _empleadoWriteServices.Update(empleadoRequest);
            return await _responseHttp.GetResponseHttp(response);
        }

        [HttpPut("DeleteLogicById{id}")]
        [ProducesResponseType(typeof(Responses<EmpleadoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Responses<EmpleadoResponse>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteLogic(int id)
        {
            var response = await _empleadoWriteServices.DeleteLogic(id);
            return await _responseHttp.GetResponseHttp(response);
        }

        [HttpDelete()]
        [ProducesResponseType(typeof(Responses<EmpleadoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Responses<EmpleadoResponse>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteById(int id)
        {
            var response = await _empleadoWriteServices.Delete(id);
            return await _responseHttp.GetResponseHttp(response);
        }
    }
}
