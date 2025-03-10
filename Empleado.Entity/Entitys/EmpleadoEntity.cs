using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Empleado.Entity.Entitys
{
    public class EmpleadoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Cargo { get; set; }
        public string EMail { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaOperacion { get; set; }
        public bool Activo { get; set; }
    }
}
