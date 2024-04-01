using GymHyR.DAL;
using Library;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GymHyR.Services;
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

    public async Task<bool> Existe(string cedula)
    {
        return await _context.Clientes.AnyAsync(c => c.Cedula == cedula);
    }

    public async Task<bool> Modificar(Clientes cliente)
    {
        _context.Entry(await _context.Clientes.FindAsync(cliente.Cedula)).State = EntityState.Detached;
        _context.Entry(cliente).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Clientes cliente)
    {
        bool cedulaExistente = await Existe(cliente.Cedula);

        if (cedulaExistente)
        {
            return false;
        }

        if (await Existe(cliente.Cedula))
            return await Modificar(cliente);
        else
            return await Insertar(cliente);
    }

    public async Task<bool> Eliminar(Clientes cliente)
    {
        _context.Entry(await _context.Clientes.FindAsync(cliente.Cedula)).State = EntityState.Detached;
        _context.Entry(cliente).State = EntityState.Deleted;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Clientes?> Buscar(string cedula)
    {
        return await _context.Clientes
            .Where(c => c.Cedula == cedula)
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

    public async Task<Clientes?> BuscarPorCedula(string cedula)
    {
        return await _context.Clientes
            .Where(c => c.Cedula == cedula)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

}