using Empleado.Application.Requests.Empleado;
using Empleado.Application.Resources;
using FluentValidation;

namespace Empleado.Application.Validations
{
    public class EmpleadoValidations : AbstractValidator<EmpleadoRequest>
    {
        public EmpleadoValidations()
        {
            RuleFor(emp => emp.Nombre).NotNull().NotEmpty().WithMessage(MessagesValidationsEmpleados.ValidationsEmpleadoApellidoNulo)
                .MaximumLength(15).WithMessage(MessagesValidationsEmpleados.ValidationsEmpleadoNombreMax15Caracteres);
            RuleFor(emp => emp.Apellido).NotNull().NotEmpty().WithMessage(MessagesValidationsEmpleados.ValidationsEmpleadoApellidoNulo)
                .MaximumLength(15).WithMessage(MessagesValidationsEmpleados.ValidationsEmpleadoApellidoMax15Caracteres); 
            RuleFor(emp => emp.EMail).NotNull().NotEmpty().WithMessage(MessagesValidationsEmpleados.ValidationsEmpleadoEMailNull)
                .MaximumLength(25).WithMessage(MessagesValidationsEmpleados.ValidationsEmpleadoMax25Caracteres)
                .EmailAddress().WithMessage(MessagesValidationsEmpleados.ValidationsEmpleadoFormatoEMailIncorrecto);
            RuleFor(emp => emp.Nombre).NotEqual(cliente => cliente.Apellido)
                .WithMessage(MessagesValidationsEmpleados.ValidationsEmpleadoNombreDistintoApellidos);
        }
    }
}
