using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public class Visitas
{
	[Key]
	public int VisitaId { get; set; }

	public string? Cedula { get; set; }

	[Required(ErrorMessage = "Este campo es requerido")]
	public DateTime Fecha { get; set; } = DateTime.Today;

}
