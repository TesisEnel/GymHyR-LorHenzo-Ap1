
using GymHyR.DAL;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymHyR.Services;
public class VentasServices(Context context)
{
    public async Task<IEnumerable<Ventas>> GetVentas()
    {
        return await context.Venta.Include(p => p.VentaDetalle)
        .Select(d => new Ventas()
        {
            VentaId = d.VentaId,
            Fecha = d.Fecha,
            VentaDetalle = d.VentaDetalle
        }).ToListAsync();
    }
    public async Task<Ventas?> GetVenta(int id)
    {
        return await context.Venta.Include(p => p.VentaDetalle)
            .Where(c => c.VentaId == id).FirstOrDefaultAsync();
    }

    public async Task<Ventas> PostVentas(Ventas Venta)
    {
        context.Venta.Add(Venta);
        await context.SaveChangesAsync();
        return Venta;
    }

    public async Task<IActionResult> PutCompras(int id, Ventas Venta)
    {
        if (id != Venta.VentaId)
        {
            return new BadRequestResult();
        }

        context.Entry(Venta).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VentaExists(id))
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

    public async Task DeleteVentas(int id)
    {
        var Compra = await context.Venta
            .FirstOrDefaultAsync(p => p.VentaId == id);

        if (Compra != null)
        {
            context.Venta.Remove(Compra);
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteDetalle(int VentaId, int detalleId)
    {
        var Venta = await context.Venta
        .Include(d => d.VentaDetalle)
            .FirstOrDefaultAsync(p => p.VentaId == VentaId);

        if (Venta != null)
        {
            var detalle = Venta.VentaDetalle.FirstOrDefault(d => d.VentaDetalleId == detalleId);
            if (detalle != null)
            {
                Venta.VentaDetalle.Remove(detalle);
                await context.SaveChangesAsync();
            }
        }
    }

    public bool VentaExists(int id)
    {
        return context.Venta.Any(e => e.VentaId == id);
    }

}
