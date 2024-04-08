using GymHyR.Data;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos = Library.Pedidos;

namespace GymHyR.Services;

public class PedidosServices(ApplicationDbContext context)
{
    public async Task<IEnumerable<Pedidos>> GetPedidos()
    {
        return await context.Pedidos
        .Select(d => new Pedidos()
        {
            PedidoId = d.PedidoId,
            FechaPedido =d.FechaPedido,
            ClienteNombre =d.ClienteNombre,
            Detalles =d.Detalles
        }).ToListAsync();
    }

    public async Task<Pedidos?> GetPedido(int id)
    {
        return await context.Pedidos.Include(p => p.Detalles)
            .Where(c => c.PedidoId == id).FirstOrDefaultAsync();
    }

    public async Task<Pedidos> PostPedidos(Pedidos pedidos)
    {
        context.Pedidos.Add(pedidos);
        await context.SaveChangesAsync();
        return pedidos;
    }
    public async Task<IActionResult> PutPedidos(int id, Pedidos pedidos)
    {
        if (id != pedidos.PedidoId)
        {
            return new BadRequestResult();
        }

        context.Entry(pedidos).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PedidosExists(id))
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

    public async Task DeletePedidos(int id)
    {
        var Pedidos = await context.Pedidos
            .FirstOrDefaultAsync(p => p.PedidoId == id);

        if (Pedidos != null)
        {
            context.Pedidos.Remove(Pedidos);
            await context.SaveChangesAsync();
        }
    }
    public bool PedidosExists(int id)
    {
        return context.Pedidos.Any(e => e.PedidoId == id);
    }

    public List<Pedidos> ObtenerPedidosCliente(int userId)
    {
        // Lógica para obtener los pedidos del cliente con el userId proporcionado
        return context.Pedidos.Where(p => p.PedidoId == userId).ToList();
    }

}
