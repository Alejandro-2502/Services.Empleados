using Empleado.Application.IComon;
using Empleado.Application.Intefaces.Validator;
using Empleado.Application.Requests.Empleado;
using Empleado.Application.Validations;

namespace Empleado.Application.Services
{
    public class ValidationsServices : IValidationsServices
    {
        private readonly EmpleadoValidations _empleadoValidation;
        private readonly ILogServices _logServices;

        public ValidationsServices(EmpleadoValidations validation, ILogServices logServices)
        {
            _empleadoValidation = validation;
            _logServices = logServices;
        }

        public async Task<List<string>> Validator(EmpleadoRequest empleadoRequest)
        {
            try
            {
                List<string> Messages = new();

                var result = _empleadoValidation.Validate(empleadoRequest);

                if (!result.IsValid)
                {
                    var errors = result.Errors
                               .Select(e => Task.Run(() => e.ErrorMessage))
                               .ToArray();

                    var resultMessages = await Task.WhenAll(errors);
                    Messages.AddRange(resultMessages);
                }
                return Messages;
            }
            catch (Exception ex)
            {
                _logServices.LogError(ex.Message);
                throw;
            }
        }
    }
}
