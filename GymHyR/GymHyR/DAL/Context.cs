using Library;
using Microsoft.EntityFrameworkCore;

namespace GymHyR.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Contactos> Contactos { get; set; }
        public DbSet<Compra> Compra { get; set; }
    }
}
