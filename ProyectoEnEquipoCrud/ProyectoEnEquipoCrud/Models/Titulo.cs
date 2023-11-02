using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEnEquipoCrud.Models
{
    public class Titulo
    {
        [Key]
        public int Id_Titulo { get; set; }
        public string titulo { get; set; }

        public string descripcion { get; set; }

        [ForeignKey("Empleado")]
        public int Id_Empleado { get; set; }
        public Empleado Empleado { get; set; }
    }
}
