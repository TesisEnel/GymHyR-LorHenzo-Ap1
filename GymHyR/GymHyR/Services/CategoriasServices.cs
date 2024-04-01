using GymHyR.DAL;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymHyR.Services;

public class CategoriasServices(Context context)
{
    public async Task<IEnumerable<Categorias>> GetCategorias()
    {
        return await context.Categorias
        .Select(d => new Categorias()
        {
            CategoriaId = d.CategoriaId,
            CategoriaNombre = d.CategoriaNombre,
            fecha = d.fecha
        }).ToListAsync();
    }

    public async Task<Categorias?> GetCategoria(int id)
    {
        return await context.Categorias.FindAsync(id);
    }

    public async Task<Categorias> PostCategoria(Categorias Categorias)
    {
        context.Categorias.Add(Categorias);
        await context.SaveChangesAsync();
        return Categorias;
    }
    public async Task<IActionResult> PutCategoria(int id, Categorias Categorias)
    {
        if (id != Categorias.CategoriaId)
        {
            return new BadRequestResult();
        }

        context.Entry(Categorias).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoriaExists(id))
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

    public async Task DeleteCategoria(int id)
    {
        var Categoria = await context.Categorias
            .FirstOrDefaultAsync(p => p.CategoriaId == id);

        if (Categoria != null)
        {
            context.Categorias.Remove(Categoria);
            await context.SaveChangesAsync();
        }
    }
    public bool CategoriaExists(int id)
    {
        return context.Categorias.Any(e => e.CategoriaId == id);
    }


}
