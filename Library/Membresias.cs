using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Membresias
    {
        [Key]
        public int MembresiaId { get; set; }

        public int ClienteId { get; set; }

        public int TipoMembresiaId { get; set; }

        public int EstadoMembresiaId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaInicio { get; set; } = DateTime.Today;
        public DateTime FechaFechaFin { get; set; } = DateTime.Today;
    }
}
