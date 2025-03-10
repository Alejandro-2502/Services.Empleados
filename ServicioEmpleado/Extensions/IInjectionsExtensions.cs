using Empleado.Application.IComon;
using Empleado.Application.Intefaces.Empleado;
using Empleado.Application.Intefaces.Validator;
using Empleado.Application.Services;
using Empleado.Application.Services.Comon;
using Empleado.Application.Services.Empleado;
using Empleado.Application.Validations;
using Empleado.Domain.Interfaces;
using Empleado.Infractutura.UnitOfWorks;

namespace ServicioEmpleado.Extensions
{
    public static class IInjectionsExtensions
    {
        public static IServiceCollection AddInjections(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmpleadoWriteServices, EmpleadoWriteServices>();
            services.AddScoped<IEmpleadoReadServices, EmpleadoReadServices>();
            
            ////----------- Validations ---------------
            services.AddScoped<EmpleadoValidations>();   
            services.AddScoped<IValidationsServices, ValidationsServices>();
            ////----------- Comunes ---------------

            services.AddScoped<ResponseHttp>();
            services.AddSingleton<ILogServices>(new LogServices("logfile.txt"));

            return services;
        }
    }
}
