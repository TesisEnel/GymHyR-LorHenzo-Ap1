using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public class PedidoDetalle
{
    public int PedidoDetalleId { get; set; }
    public int ProductoId { get; set; }
    public string ProductoNombre { get; set; }
    public decimal PrecioUnitario { get; set; }
    public int Cantidad { get; set; }
    public decimal Total { get { return PrecioUnitario * Cantidad; } } // Calculated property
}
