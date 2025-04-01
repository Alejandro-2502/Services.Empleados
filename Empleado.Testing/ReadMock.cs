using Empleado.Application.DTOs;
using Empleado.Application.Responses.Empleado;
using Empleado.Entity.Entitys;

namespace Empleado.Testing;

public static class ReadMock
{
   
    public static List<EmpleadoResponse> GetAllResponseOk()
    {
        var empleadosResponse = new List<EmpleadoResponse>()
        {
             new EmpleadoResponse { Id = 1, Nombre = "Juan", Apellido = "Fernandez", Cargo = "Gerente", Edad = 39, EMail = "fernandez@hotmail.com" },
             new EmpleadoResponse { Id = 2, Nombre = "Martin", Apellido = "Gutierrez", Cargo = "Director", Edad = 45, EMail = "Gutierrez@hotmail.com" }
        };

        return empleadosResponse;
    }

    public static List<EmpleadoDTO> GetAllDtoNull()
    {  
        return null;
    }
    public static IQueryable<EmpleadoEntity> GetAllQueryOk()
    {
        var empleadosEntity = new List<EmpleadoEntity>
        {
            new EmpleadoEntity { Id = 1, Nombre = "Juan", Apellido = "Fernandez", Cargo = "Gerente", Edad = 39, EMail = "fernandez@hotmail.com" },
            new EmpleadoEntity { Id = 2, Nombre = "Martin", Apellido = "Gutierrez", Cargo = "Director", Edad = 45, EMail = "Gutierrez@hotmail.com" }
        };

        return empleadosEntity.AsQueryable();
    }

    public static EmpleadoEntity GetByIdEntityOk()
    {  
      return new EmpleadoEntity { Id = 1, Nombre = "German", Apellido = "Abaroa", Cargo = "Vendedor", Edad = 56, EMail = "abaroa@hotmail.com" };   
    }

    public static EmpleadoResponse GetByIdResponseOk()
    {    
        return new EmpleadoResponse { Id = 1, Nombre = "Juan", Apellido = "Fernandez", Cargo = "Gerente", Edad = 39, EMail = "fernandez@hotmail.com" };
    }

    public static List<EmpleadoEntity> GetByEdadMayorIgualEntityOk()
    {
        var empleadosEntity = new List<EmpleadoEntity>
        {
           new EmpleadoEntity { Id = 1, Nombre = "German", Apellido = "Abaroa", Cargo = "Vendedor", Edad = 56, EMail = "abaroa@hotmail.com" },
           new EmpleadoEntity { Id = 2, Nombre = "Federico", Apellido = "Maipu", Cargo = "Director", Edad = 59, EMail = "Gutierrez@hotmail.com" }
        };

        return empleadosEntity;
    }

    public static List<EmpleadoDTO> GetByEdadMayorIgualDTOok()
    {
        var empleadosDTO = new List<EmpleadoDTO>
        {
           new EmpleadoDTO { Id = 1, Nombre = "German", Apellido = "Abaroa", Cargo = "Vendedor", Edad = 56, EMail = "abaroa@hotmail.com" },
           new EmpleadoDTO { Id = 2, Nombre = "Federico", Apellido = "Maipu", Cargo = "Director", Edad = 59, EMail = "Gutierrez@hotmail.com" }
        };

        return empleadosDTO;
    }

    public static List<EmpleadoResponse> GetByEdadMayorIgualResponseOk()
    {
        var empleadosResponse = new List<EmpleadoResponse>()
        {
            new EmpleadoResponse { Id = 1, Nombre = "German", Apellido = "Abaroa", Cargo = "Vendedor", Edad = 56, EMail = "abaroa@hotmail.com" },
            new EmpleadoResponse { Id = 2, Nombre = "Federico", Apellido = "Maipu", Cargo = "Director", Edad = 59, EMail = "Gutierrez@hotmail.com" }
        };

        return empleadosResponse;
    }
}