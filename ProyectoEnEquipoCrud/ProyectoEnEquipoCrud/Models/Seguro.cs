using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEnEquipoCrud.Models
{
    public class Salario
    {
        [Key]
        public int idsalario { get; set; }
        public decimal salario { get; set; }
        public DateTime fechainicio { get; set; }
    }
}
