using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public class Membresias
{
    [Key]
    public int MembresiaId { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public string? Cedula { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public int TipoMembresiaId { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public int EstadoMembresiaId { get; set; }

    public decimal valor { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public DateTime FechaInicio { get; set; } = DateTime.Today;
    public DateTime FechaFechaFin { get; set; } = DateTime.Today;

    [ForeignKey("MembresiaId")]
    public ICollection<Visitas> Visitas { get; set; } = new List<Visitas>();
}
