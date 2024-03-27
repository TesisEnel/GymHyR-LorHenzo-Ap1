using GymHyR.DAL;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymHyR.Services;

public class ProveedoresServices(Context context)
{
    public async Task<IEnumerable<Proveedores>> GetProveedores()
    {
        return await context.Proveedores.Include(p => p.ProveedoresDetalle)
        .Select(d => new Proveedores()
        {
            ProveedorId = d.ProveedorId,
            FechaCreacion = d.FechaCreacion,
            Nombre = d.Nombre,
            Direccion = d.Direccion,
            Email = d.Email,
            RNC = d.RNC,
        }).ToListAsync();
    }

    public async Task<Proveedores?> GetProveedor(int id)
    {
        return await context.Proveedores.Include(p => p.ProveedoresDetalle).FirstOrDefaultAsync(p => p.ProveedorId == id);
    }

    public async Task<Proveedores> PostProveedores(Proveedores Proveedores)
    {
        context.Proveedores.Add(Proveedores);
        await context.SaveChangesAsync();
        return Proveedores;
    }
    public async Task<IActionResult> PutProveedores(int id, Proveedores Proveedores)
    {
        if (id != Proveedores.ProveedorId)
        {
            return new BadRequestResult();
        }

        context.Entry(Proveedores).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProveedoresExists(id))
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

    public async Task DeleteProvedores(int id)
    {
        var Proveedores = await context.Proveedores
            .FirstOrDefaultAsync(p => p.ProveedorId == id);

        if (Proveedores != null)
        {
            context.Proveedores.Remove(Proveedores);
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteDetalle(int proveedorId, int detalleId)
    {
        var proveedor = await context.Proveedores
            .Include(d => d.ProveedoresDetalle)
            .FirstOrDefaultAsync(p => p.ProveedorId == proveedorId);

        if (proveedor != null)
        {
            var detalle = proveedor.ProveedoresDetalle.FirstOrDefault(d => d.DetalleId == detalleId);
            if (detalle != null)
            {
                proveedor.ProveedoresDetalle.Remove(detalle);
                await context.SaveChangesAsync();
            }
        }
    }
    public bool ProveedoresExists(int id)
    {
        return context.Proveedores.Any(e => e.ProveedorId == id);
    }

}
