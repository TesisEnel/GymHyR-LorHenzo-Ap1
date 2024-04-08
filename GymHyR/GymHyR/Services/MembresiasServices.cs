using GymHyR.Data;
using Library;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GymHyR.Services;
public class MembresiasServices
{
    private readonly ApplicationDbContext _context;

    public MembresiasServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Insertar(Membresias membresia)
    {
        await _context.Membresias.AddAsync(membresia);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int membresiaId)
    {
        return await _context.Membresias.AnyAsync(m => m.MembresiaId == membresiaId);
    }

    public async Task<bool> Modificar(Membresias membresia)
    {
        _context.Entry(membresia).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Membresias membresia)
    {
        if (await Existe(membresia.MembresiaId))
            return await Modificar(membresia);
        else
            return await Insertar(membresia);
    }

    public async Task<bool> Eliminar(Membresias membresia)
    {
        _context.Membresias.Remove(membresia);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Membresias?> Buscar(int membresiaId)
    {
        return await _context.Membresias.FindAsync(membresiaId);
    }

    public async Task<List<Membresias>> GetList(Expression<Func<Membresias, bool>> criterio)
    {
        return await _context.Membresias.Where(criterio).ToListAsync();
    }

    public async Task<bool> ClienteTieneMembresia(string cedula)
    {
        return await _context.Membresias.AnyAsync(m => m.Cedula == cedula);
    }

    public async Task<bool> ClienteTieneMembresia(string cedula, string codigo)
    {
        return await _context.Membresias.AnyAsync(m => m.Cedula == cedula &&
                                                        m.Codigo == codigo &&
                                                        m.EstadoMembresiaId == 1);
    }

    public async Task<List<Membresias>> BuscarPorCedula(string cedula)
    {
        return await _context.Membresias.Where(m => m.Cedula == cedula).ToListAsync();
    }



}