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
    [StringLength(13, MinimumLength = 13, ErrorMessage = "La cédula debe tener 13 caracteres")]
    [RegularExpression(@"^\d{3}-\d{7}-\d{1}$", ErrorMessage = "El formato de la cédula debe ser XXX-XXXXXXX-X")]
    public string? Cedula { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public int TipoMembresiaId { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public int EstadoMembresiaId { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public decimal valor { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public string Codigo { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public DateTime FechaInicio { get; set; } = DateTime.Today;
    public DateTime FechaFechaFin { get; set; } = DateTime.Today;

    [ForeignKey("MembresiaId")]
    public ICollection<Visitas> Visitas { get; set; } = new List<Visitas>();
}
