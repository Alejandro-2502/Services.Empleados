using AutoMapper;
using Empleado.Application.Configurations;
using Empleado.Application.Mappers;
using Empleado.Infractutura.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ServicioEmpleado.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection Configure(this IServiceCollection services, WebApplicationBuilder webApplicationBuilder, IConfiguration configuration)
        {
            ConfigHelper.ConfigSqlServer = configuration.GetSection(nameof(ConfigSqlServer)).Get<ConfigSqlServer>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            AddConfigureSwagger(services);
            services.AddMvc();
            services.AddInjections();
            services.AddAutoMapper();
            AddUseSqlServer(services, configuration);
            return services;
        }

        public static IServiceCollection AddConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { Title = "MicroServicio Empleado", Version = "v1" });
            });

            return services;
        }
        public static IServiceCollection AddUseSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString(ConfigHelper.ConfigSqlServer.Connection)));

            return services;
        }
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(typeof(MapperProfile));
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
