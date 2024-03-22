using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ProductoDto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int cantidad { get; set; }

    }
}
