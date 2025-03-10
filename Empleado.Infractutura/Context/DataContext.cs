using Empleado.Application.Configurations;
using Empleado.Entity.Entitys;
using Empleado.Infractutura.Builder;
using Microsoft.EntityFrameworkCore;

namespace Empleado.Infractutura.Context
{
    public class DataContext : DbContext
    {
        protected DataContext(){}

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<EmpleadoEntity> Empleado { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer(ConfigHelper.ConfigSqlServer.Connection);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .ApplyConfiguration(new EmpleadoBuilder());

        }
    }
}
