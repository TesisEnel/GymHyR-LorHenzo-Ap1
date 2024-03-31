using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Contactos
    {
        [Key]
        public int ContactoId { get; set; }

        public string Descripcion { get; set; }

	}
}
