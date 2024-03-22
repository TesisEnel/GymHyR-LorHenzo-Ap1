using GymHyR.Data;
using GymHyR.Models;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymHyR.Services
{
    public class ProductosServices(ApplicationDbContext context)
    {
        public async Task<IEnumerable<ProductoDto>> GetProductos()
        {
            return await context.Productos
                .Select(d => new ProductoDto()
                {
                    ProductoId = d.ProductoId,
                    Nombre = d.Nombre,
                    Precio = d.Precio,
                    cantidad = d.cantidad
                }).ToListAsync();
        }

        public async Task<Producto?> GetProducto(int id)
        {
            return await context.Productos.FindAsync(id);
        }

        public async Task<Producto> PostProducto(Producto producto)
        {
            context.Productos.Add(producto);
            await context.SaveChangesAsync();
            return producto;
        }
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.ProductoId)
            {
                return new BadRequestResult();
            }

            context.Entry(producto).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return new NotFoundResult();
                }
                else
                {
                    throw;
                }
            }

            return new NoContentResult();
        }

        public async Task<bool> DeleteProducto(Producto producto)
        {
            var cantidad = await context.Productos
                .Where(c => c.ProductoId == producto.ProductoId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }
        public bool ProductoExists(int id)
        {
            return context.Productos.Any(e => e.ProductoId == id);
        }
    }
}
