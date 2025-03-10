using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empleado.Infractutura.Migrations
{
    /// <inheritdoc />
    public partial class NuevosCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "EMPLEADO",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "EMPLEADO");
        }
    }
}
