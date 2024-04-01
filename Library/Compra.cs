using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public class Compra
{
    [Key]
    public int CompraId { get; set; }
    public DateTime FecheDeCompra { get; set; } = DateTime.Now;

	[ForeignKey("CompraId")]
	public ICollection<CompraDetalle> CompraDetalles { get; set; } = new List<CompraDetalle>();
}
