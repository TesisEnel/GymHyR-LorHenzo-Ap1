using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Entrenador
    {
        [Key]
        public int EntrenadorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime Fecha { get; set; } = DateTime.Today;

        [StringLength(200)]
        public string Descripcion { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int HorarioEntrenadorId { get; set; }

        [ForeignKey("EntrenadorId")]
        public ICollection<CitasEntrenamiento> CitasEntretamiento { get; set; } = new List<CitasEntrenamiento>();
    }
}
