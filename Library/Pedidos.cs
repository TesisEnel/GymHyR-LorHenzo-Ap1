using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public class Pedido
{
    public int PedidoId { get; set; }
    public DateTime FechaPedido { get; set; }
    public string ClienteNombre { get; set; }
    public List<PedidoDetalle> Detalles { get; set; } = new List<PedidoDetalle>();
}
