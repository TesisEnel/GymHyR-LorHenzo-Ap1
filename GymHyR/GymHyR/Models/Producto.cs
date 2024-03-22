using System.ComponentModel.DataAnnotations;

namespace GymHyR.Models;

public class Producto
{
    [Key]
    public int ProductoId { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int cantidad { get; set; }

}
