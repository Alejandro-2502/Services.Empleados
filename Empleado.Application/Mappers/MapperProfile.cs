using AutoMapper;
using Empleado.Application.DTOs;
using Empleado.Application.Requests.Empleado;
using Empleado.Application.Responses.Empleado;
using Empleado.Entity.Entitys;

namespace Empleado.Application.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<EmpleadoRequest, EmpleadoEntity>();
            CreateMap<EmpleadoEntity, EmpleadoResponse>();
            CreateMap<EmpleadoEntity,EmpleadoDTO>();
            CreateMap<EmpleadoDTO,EmpleadoResponse>();
        }
    }
}
