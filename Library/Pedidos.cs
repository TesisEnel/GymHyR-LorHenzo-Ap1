using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public class Pedidos
{
    [Key]
    public int PedidoId { get; set; }
    public DateTime FechaPedido { get; set; }
    public string ClienteNombre { get; set; }


    [ForeignKey("PedidoId")]
    public List<PedidoDetalle> Detalles { get; set; } = new List<PedidoDetalle>();
}
