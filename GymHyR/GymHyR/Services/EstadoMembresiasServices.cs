using GymHyR.DAL;
using Library;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GymHyR.Services
{
    public class EstadoMembresiasServices
    {
        private readonly Context _context;

        public EstadoMembresiasServices(Context context)
        {
            _context = context;
        }

        public async Task<List<EstadoMembresias>> GetList(Expression<Func<EstadoMembresias, bool>> criterio)
        {
            return await _context.EstadoMembresias
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<EstadoMembresias?> Buscar(int estadoMembresiaId)
        {
            return await _context.EstadoMembresias
                .Where(e => e.EstadoMembresiaId == estadoMembresiaId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
