using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class CitasEntretamiento
    {
        [Key]
        public int CitasEntretamientoId { get; set; }

        public int EntrenadorId { get; set; }

        public DateTime FechaCita { get; set; }

        public TimeSpan HoraCita { get; set; }

        

    }
}
