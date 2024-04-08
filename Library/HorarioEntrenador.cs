using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class HorarioEntrenador
    {
        [Key]
        public int HorarioEntrenadorId { get; set; }

        [StringLength(200)]
        public string Descripcion { get; set; }


        [ForeignKey("HorarioEntrenadorId")]
        public ICollection<Entrenador> Entrenador { get; set; } = new List<Entrenador>();
    }
}
