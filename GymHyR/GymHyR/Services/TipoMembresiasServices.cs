using GymHyR.DAL;
using Library;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GymHyR.Services;

public class TipoMembresiasServices
{
    private readonly Context _context;

    public TipoMembresiasServices(Context context)
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
