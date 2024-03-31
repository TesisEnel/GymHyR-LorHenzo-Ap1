using GymHyR.DAL;
using Library;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GymHyR.Services
{
    public class ClientesServices
    {
        private readonly Context _context;

        public ClientesServices(Context context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(Clientes cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Existe(int clienteId)
        {
            return await _context.Clientes.AnyAsync(c => c.ClienteId == clienteId);
        }

        public async Task<bool> Modificar(Clientes cliente)
        {
            _context.Entry(await _context.Clientes.FindAsync(cliente.ClienteId)).State = EntityState.Detached;
            _context.Entry(cliente).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Clientes cliente)
        {
            bool cedulaExistente = await ExisteCedula(cliente.Cedula);

            if (cedulaExistente)
            {
                return false;
            }

            if (await Existe(cliente.ClienteId))
                return await Modificar(cliente);
            else
                return await Insertar(cliente);
        }

        public async Task<bool> Eliminar(Clientes cliente)
        {
            _context.Entry(await _context.Clientes.FindAsync(cliente.ClienteId)).State = EntityState.Detached;
            _context.Entry(cliente).State = EntityState.Deleted;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Clientes?> Buscar(int clienteId)
        {
            return await _context.Clientes
                .Where(c => c.ClienteId == clienteId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<List<Clientes>> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            return await _context.Clientes
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<bool> ExisteCedula(string cedula)
        {
            return await _context.Clientes.AnyAsync(c => c.Cedula == cedula);
        }
    }
}
