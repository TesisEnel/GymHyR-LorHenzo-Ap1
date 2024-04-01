using GymHyR.DAL;
using Library;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GymHyR.Services;
public class VisitasServices
{
    private readonly Context _context;

    public VisitasServices(Context context)
    {
        _context = context;
    }

    public async Task<bool> Insertar(Visitas visita)
    {
        await _context.Visitas.AddAsync(visita);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int visitaId)
    {
        return await _context.Visitas.AnyAsync(v => v.VisitaId == visitaId);
    }

    public async Task<bool> Modificar(Visitas visita)
    {
        _context.Entry(await _context.Visitas.FindAsync(visita.VisitaId)).State = EntityState.Detached;
        _context.Entry(visita).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Visitas visita)
    {
        if (await Existe(visita.VisitaId))
            return await Modificar(visita);
        else
            return await Insertar(visita);
    }

    public async Task<bool> Eliminar(Visitas visita)
    {
        _context.Entry(await _context.Visitas.FindAsync(visita.VisitaId)).State = EntityState.Detached;
        _context.Entry(visita).State = EntityState.Deleted;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Visitas?> Buscar(int visitaId)
    {
        return await _context.Visitas
            .Where(v => v.VisitaId == visitaId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task<List<Visitas>> GetList(Expression<Func<Visitas, bool>> criterio)
    {
        return await _context.Visitas
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    // Puedes agregar métodos adicionales según sea necesario

}
