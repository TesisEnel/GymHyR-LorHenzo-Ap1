using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime Fecha { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Este campo es requerido")]
        public string? Cedula { get; set; }

        //[EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        public string? Gmail { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string? Telefono { get; set; }

        [ForeignKey("ClienteId")]
        public ICollection<Membresias> Membresias { get; set; } = new List<Membresias>();
    }

}
