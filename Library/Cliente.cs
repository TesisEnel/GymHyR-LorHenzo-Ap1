using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public class Clientes
{
    [Key]
    [Required(ErrorMessage = "La cédula es obligatoria")]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "La cédula debe tener 13 caracteres")]
    [RegularExpression(@"^\d{3}-\d{7}-\d{1}$", ErrorMessage = "El formato de la cédula debe ser XXX-XXXXXXX-X")]
    public string? Cedula { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public DateTime Fecha { get; set; } = DateTime.Today;

    [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
    public string? Gmail { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Ingrese un número de teléfono válido")]
    public string? Telefono { get; set; }

    [ForeignKey("Cedula")]
    public ICollection<Membresias> Membresias { get; set; } = new List<Membresias>();

    [ForeignKey("Cedula")]
    public ICollection<Visitas> Visitas { get; set; } = new List<Visitas>();
}
