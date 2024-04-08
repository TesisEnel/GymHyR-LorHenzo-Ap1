using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class CitasEntrenamiento
    {
        [Key]
        public int CitasEntrenamientoId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int EntrenadorId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int HorarioEntrenadorId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaCita { get; set; }






    }
}
