using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public class Categorias
{
    [Key]
    public int CategoriaId { get; set; }
    public string CategoriaNombre { get; set; }
    public DateTime fecha { get; set; } = DateTime.Now;

}
