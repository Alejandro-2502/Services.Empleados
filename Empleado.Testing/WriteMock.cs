using Empleado.Application.Requests.Empleado;
using Empleado.Application.Responses.Empleado;
using Empleado.Entity.Entitys;

namespace Empleado.Testing
{
    public static class WriteMock
    {
        public static EmpleadoEntity AddEntityOk()
        {
            return new EmpleadoEntity { Id = 1, Nombre = "Juan", Apellido = "Fernandez", Cargo = "Gerente", Edad = 39, EMail = "fernandez@hotmail.com" };
        }

        public static EmpleadoResponse AddResponseOk()
        {
            return new EmpleadoResponse { Id = 1, Nombre = "Juan", Apellido = "Fernandez", Cargo = "Gerente", Edad = 39, EMail = "fernandez@hotmail.com" };
        }

        public static EmpleadoRequest AddRequestOk()
        {
            return new EmpleadoRequest { Id = 1, Nombre = "Juan", Apellido = "Fernandez", Cargo = "Gerente", Edad = 39, EMail = "fernandez@hotmail.com" };
        }

        public static EmpleadoEntity UpdateEntityOk()
        {
            return new EmpleadoEntity { Id = 1, Nombre = "Alejandro", Apellido = "Winkler", Cargo = "Vendedor", Edad = 56, EMail = "Alejandro@hotmail.com" };
        }

        public static EmpleadoResponse UpdateResponseOk()
        {
            return new EmpleadoResponse { Id = 1, Nombre = "Alejandro", Apellido = "Winkler", Cargo = "Vendedor", Edad = 56, EMail = "Alejandro@hotmail.com" };
        }

        public static EmpleadoRequest UpdateRequestOk()
        {
            return new EmpleadoRequest { Id = 1, Nombre = "Alejandro", Apellido = "Winkler", Cargo = "Vendedor", Edad = 56, EMail = "Alejandro@hotmail.com" };
        }
    }
}
