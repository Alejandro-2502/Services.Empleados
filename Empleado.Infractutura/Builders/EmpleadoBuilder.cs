using Empleado.Entity.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empleado.Infractutura.Builder
{
    public class EmpleadoBuilder : IEntityTypeConfiguration<EmpleadoEntity>
    {
        public void Configure(EntityTypeBuilder<EmpleadoEntity> entity)
        {
            entity.ToTable("EMPLEADO");

            entity.Property(e => e.Nombre)
                .HasMaxLength(30);

            entity.Property(e => e.Apellido)
                .HasMaxLength(30);

            entity.Property(e => e.Cargo)
                .HasMaxLength(15);

            entity.Property(e => e.EMail)
              .HasMaxLength(40);

            entity.Property(e => e.Edad);
            entity.Property(e => e.FechaNacimiento);
            entity.Property(e => e.FechaAlta);
            entity.Property(e => e.Activo);
            entity.Property(e => e.FechaOperacion);

    }
    }
}
