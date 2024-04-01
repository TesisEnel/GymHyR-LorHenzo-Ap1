using GymHyR.Data;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymHyR.Services;

public class ComprasServices(ApplicationDbContext context)
{
	public async Task<IEnumerable<Compra>> GetCompras()
	{
		return await context.Compra.Include(p => p.CompraDetalles)
		.Select(d => new Compra()
		{
			CompraId = d.CompraId,
			FecheDeCompra = d.FecheDeCompra,
			CompraDetalles = d.CompraDetalles
		}).ToListAsync();
	}

	public async Task<Compra?> GetCompra(int id)
	{
		return await context.Compra.Include(c => c.CompraDetalles)
			.Where(c => c.CompraId == id).FirstOrDefaultAsync();
	}

	public async Task<Compra> PostCompras(Compra Compra)
    {
        context.Compra.Add(Compra);
        await context.SaveChangesAsync();
        return Compra;

		//if (!ComprasExists(Compra.CompraId))
		//	context.Compra.Add(Compra);
		//else
		//	context.Compra.Update(Compra);

		//await context.SaveChangesAsync();

		//return new OkObjectResult(Compra);
	}
	public async Task<IActionResult> PutCompras(int id, Compra Compra)
	{
		if (id != Compra.CompraId)
		{
			return new BadRequestResult();
		}

		context.Entry(Compra).State = EntityState.Modified;

		try
		{
			await context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!ComprasExists(id))
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

	public async Task DeleteCompras(int id)
	{
		var Compra = await context.Compra
			.FirstOrDefaultAsync(p => p.CompraId == id);

		if (Compra != null)
		{
			context.Compra.Remove(Compra);
			await context.SaveChangesAsync();
		}
	}

	public async Task DeleteDetalle(int CompraId, int detalleId)
	{
		var Compra = await context.Compra
			.Include(d => d.CompraDetalles)
			.FirstOrDefaultAsync(p => p.CompraId == CompraId);

		if (Compra != null)
		{
			var detalle = Compra.CompraDetalles.FirstOrDefault(d => d.CompraDetalleId == detalleId);
			if (detalle != null)
			{
				Compra.CompraDetalles.Remove(detalle);
				await context.SaveChangesAsync();
			}
		}
	}
	public bool ComprasExists(int id)
	{
		return context.Compra.Any(e => e.CompraId == id);
	}
}
