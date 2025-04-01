using AutoMapper;
using Empleado.Application.Comon;
using Empleado.Application.DTOs;
using Empleado.Application.Generics;
using Empleado.Application.IComon;
using Empleado.Application.Intefaces.Empleado;
using Empleado.Application.Responses.Empleado;
using Empleado.Domain.Interfaces;
using System.Net;

namespace Empleado.Application.Services.Empleado
{
    public class EmpleadoReadServices : IEmpleadoReadServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogServices _logServices;
        public EmpleadoReadServices(IUnitOfWork unitOfWork, IMapper mapper, ILogServices logServices)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logServices = logServices;
        }
        public async Task<Responses<List<EmpleadoResponse>>> GetAll()
        {
            try
            {
                var results = await _unitOfWork.empleadoRepository.GetAllAsync();

                if (!results.Any())
                    return await Response.Error<List<EmpleadoResponse>>(HttpStatusCode.NotFound, Resources.MessagesResource.EmpleadoServicioNotFoundAll);

                var empleadosResponse = _mapper.Map<List<EmpleadoResponse>>(results);
                return await Response.Ok(HttpStatusCode.OK, string.Empty, empleadosResponse);
            }
            catch (Exception ex)
            {
                _logServices.LogError(ex.Message);
                return await Response.Error<List<EmpleadoResponse>>(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        public async Task<Responses<List<EmpleadoResponse>>> GetByEdadMayorIgual(int edad)
        {
            try
            {
                var results = await _unitOfWork.empleadoRepository.GetByEdadMayotIgual(edad);

                if (!results.Any())
                    return await Response.Error<List<EmpleadoResponse>>(HttpStatusCode.NotFound, Resources.MessagesResource.EmpleadoServicoNotFoundByEdadMayorIgual);

                var empleadosDTO = _mapper.Map<List<EmpleadoDTO>>(results);
                var empleadosResponse = _mapper.Map<List<EmpleadoResponse>>(empleadosDTO);
                return await Response.Ok(HttpStatusCode.OK, string.Empty, empleadosResponse);
            }
            catch (Exception ex)
            {
                _logServices.LogError(ex.Message);
                return await Response.Error<List<EmpleadoResponse>>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<Responses<EmpleadoResponse>> GetById(int id)
        {
            try
            {
                var result = await _unitOfWork.empleadoRepository.GetAsync(id);

                if (result is null)
                    return await Response.Error<EmpleadoResponse>(HttpStatusCode.NotFound, Resources.MessagesResource.EmpleadoServicioNotFoundById);

                var response = _mapper.Map<EmpleadoResponse>(result);

                return await Response.Ok(HttpStatusCode.OK, string.Empty, response);
            }
            catch (Exception ex)
            {
                _logServices.LogError(ex.Message);
                return await Response.Error<EmpleadoResponse>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<Responses<List<EmpleadoResponse>>> GetEmpleadosActive(bool active)
        {
            try
            {
                var results = await _unitOfWork.empleadoRepository.GetEmpleadosActive(active);

                if (!results.Any())
                    return await Response.Error<List<EmpleadoResponse>>(HttpStatusCode.NotFound, Resources.MessagesResource.EmpleadoServicioNotFoundActiveNoActiveOk);

                var empleadosResponse = _mapper.Map<List<EmpleadoResponse>>(results);
                return await Response.Ok(HttpStatusCode.OK, string.Empty, empleadosResponse);
            }
            catch (Exception ex)
            {
                _logServices.LogError(ex.Message);
                return await Response.Error<List<EmpleadoResponse>>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
