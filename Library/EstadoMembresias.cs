using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{

    public class EstadoMembresias
    {

        [Key]
        public int EstadoMembresiaId { get; set; }

        public string? Descripcion { get; set; }

        [ForeignKey("EstadoMembresiaId")]
        public ICollection<Membresias> Membresias { get; set; } = new List<Membresias>();

    }
}
