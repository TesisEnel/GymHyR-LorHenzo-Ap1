using Library;
using Microsoft.EntityFrameworkCore;

namespace GymHyR.DAL;

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
    public DbSet<CompraDetalle> CompraDetalle { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Membresias> Membresias { get; set; }
    public DbSet<TipoMembresias> TipoMembresias { get; set; }
    public DbSet<EstadoMembresias> EstadoMembresias { get; set; }
    public DbSet<Visitas> Visitas { get; set; }
    public DbSet<Ventas> Venta { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TipoMembresias>().HasData(new TipoMembresias() { TipoMembresiaId = 1, Descripcion = "Mensual", DiasDuracion = 30, });
        modelBuilder.Entity<TipoMembresias>().HasData(new TipoMembresias() { TipoMembresiaId = 2, Descripcion = "Semanal", DiasDuracion = 5 });
        modelBuilder.Entity<TipoMembresias>().HasData(new TipoMembresias() { TipoMembresiaId = 3, Descripcion = "Diario", DiasDuracion = 1 });

        modelBuilder.Entity<EstadoMembresias>().HasData(new EstadoMembresias() { EstadoMembresiaId = 1, Descripcion = "Activa" });
        modelBuilder.Entity<EstadoMembresias>().HasData(new EstadoMembresias() { EstadoMembresiaId = 2, Descripcion = "Vencida" });
    }
}
