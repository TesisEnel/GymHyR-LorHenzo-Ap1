using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public class Proveedores
{
    [Key]
    public int ProveedorId { get; set; }

    [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
    public DateTime FechaCreacion { get; set; } = DateTime.Today;
    public byte[]? Foto { get; set; }

    [Required(ErrorMessage = "Debe ingresar un nombre.")]
    [RegularExpression(@"^[a-zA-ZñÑ\s]+$", ErrorMessage = "Este campo no acepta números ni caracteres especiales.")]
    [StringLength(15, ErrorMessage = "El nombre es demasiado largo, el límite es de 15 caracteres.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "Debe ingresar una dirección.")]
    [StringLength(70, ErrorMessage = "La dirección es demasiado larga, el límite es de 70 caracteres.")]
    public string Direccion { get; set; }

    [Required(ErrorMessage = "Debe ingresar un email")]
    [EmailAddress(ErrorMessage = "El formato para el email no es válido.")]
    [StringLength(40, ErrorMessage = "La email es demasiado largo, el límite es de 40 caracteres.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Debe ingresar un número de RNC")]
    [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "El RNC debe tener exactamente 11 dígitos numéricos.")]
    public string RNC { get; set; }


    [ForeignKey("ProveedorId")]
    public ICollection<ProveedorDetalle> ProveedoresDetalle { get; set; } = new List<ProveedorDetalle>();
}
