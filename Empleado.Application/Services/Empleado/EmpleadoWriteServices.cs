using System.Net;
using AutoMapper;
using Empleado.Application.Comon;
using Empleado.Application.Generics;
using Empleado.Application.IComon;
using Empleado.Application.Intefaces.Empleado;
using Empleado.Application.Intefaces.Validator;
using Empleado.Application.Requests.Empleado;
using Empleado.Application.Responses.Empleado;
using Empleado.Domain.Interfaces;
using Empleado.Entity.Entitys;

namespace Empleado.Application.Services.Empleado
{
    public class EmpleadoWriteServices : IEmpleadoWriteServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidationsServices _Validations;
        private readonly ILogServices _logServices;

        public EmpleadoWriteServices(IUnitOfWork unitOfWork, IMapper mapper, IValidationsServices validations, ILogServices logServices)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _Validations = validations;
            _logServices = logServices;
        }
        public async Task<Responses<EmpleadoResponse>> Delete(int id)
        {
            try
            {
                var result = await _unitOfWork.empleadoRepository.GetAsync(id);

                if (result is null)
                    return await Response.Error<EmpleadoResponse>(HttpStatusCode.Conflict, Resources.MessagesResource.EmpleadoServicioConflictDelete);

                await _unitOfWork.empleadoRepository.DeleteAsync(result);
                await _unitOfWork.SaveChangesAsync();

                var response = _mapper.Map<EmpleadoResponse>(result);

                return await Response.Ok<EmpleadoResponse>(HttpStatusCode.OK, Resources.MessagesResource.EmpleadoServicioOkDelete);
            }
            catch (Exception ex)
            {
                _logServices.LogError(ex.Message);
                return await Response.Error<EmpleadoResponse>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        public async Task<Responses<EmpleadoResponse>> DeleteLogic(int id)
        {
            try
            {
                var isActive = false;

                var result = await _unitOfWork.empleadoRepository.GetAsync(id);

                if (result is null)
                    return await Response.Error<EmpleadoResponse>(HttpStatusCode.Conflict, Resources.MessagesResource.EmpleadoServicioNotFoundById);

                await _unitOfWork.empleadoRepository.DeleteLogicAsync(id, isActive);
                await _unitOfWork.SaveChangesAsync();

                var resultUptade = await _unitOfWork.empleadoRepository.GetAsync(id);

                var response = _mapper.Map<EmpleadoResponse>(resultUptade);

                return await Response.Ok<EmpleadoResponse>(HttpStatusCode.OK, Resources.MessagesResource.EmpleadoServicioOkDeleteLogic);
            }
            catch (Exception ex)
            {
                _logServices.LogError(ex.Message);
                return await Response.Error<EmpleadoResponse>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        public async Task<Responses<EmpleadoResponse>> Insert(EmpleadoRequest request)
        {
            try
            {
                var resultValidator = await _Validations.Validator(request);

                if (resultValidator.Any())
                    return await Response.ErrorsList<EmpleadoResponse>(HttpStatusCode.BadRequest, resultValidator);

                var entity = _mapper.Map<EmpleadoEntity>(request);
                entity.FechaOperacion = DateTime.Now;
                var result = await _unitOfWork.empleadoRepository.AddAsync(entity);

                if (result is null)
                    return await Response.Error<EmpleadoResponse>(HttpStatusCode.Conflict, Resources.MessagesResource.EmpleadoServicioConflictAdd);


                await _unitOfWork.SaveChangesAsync();
                var response = _mapper.Map<EmpleadoResponse>(result);

                return await Response.Ok<EmpleadoResponse>(HttpStatusCode.OK, Resources.MessagesResource.EmpleadoServicioOkAdd);
            }
            catch (Exception ex)
            {
                _logServices.LogError(ex.Message);
                return await Response.Error<EmpleadoResponse>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        public async Task<Responses<EmpleadoResponse>> Update(EmpleadoRequest request)
        {
            try
            {
                var resultValidator = await _Validations.Validator(request);

                if (resultValidator.Any())
                    return await Response.ErrorsList<EmpleadoResponse>(HttpStatusCode.BadRequest, resultValidator);


                var entity = _mapper.Map<EmpleadoEntity>(request);
                var result = await _unitOfWork.empleadoRepository.UpdateAsync(entity);

                if (result is null)
                    return await Response.Error<EmpleadoResponse>(HttpStatusCode.Conflict, Resources.MessagesResource.EmpleadoServicioConflictUpdate);

                await _unitOfWork.SaveChangesAsync();
                var response = _mapper.Map<EmpleadoResponse>(result);

                return await Response.Ok<EmpleadoResponse>(HttpStatusCode.OK, Resources.MessagesResource.EmpleadoServicioOkUpdate);
            }
            catch (Exception ex)
            {
                _logServices.LogError(ex.Message);
                return await Response.Error<EmpleadoResponse>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
