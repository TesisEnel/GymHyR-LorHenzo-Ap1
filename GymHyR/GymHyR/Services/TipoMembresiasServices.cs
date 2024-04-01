using GymHyR.Data;
using Library;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GymHyR.Services;

public class TipoMembresiasServices
{
    private readonly ApplicationDbContext _context;

    public TipoMembresiasServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TipoMembresias>> GetList(Expression<Func<TipoMembresias, bool>> criterio)
    {
        return await _context.TipoMembresias
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
    public async Task<TipoMembresias?> Buscar(int tipoMembresiaId)
    {
        return await _context.TipoMembresias
            .Where(t => t.TipoMembresiaId == tipoMembresiaId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

}
