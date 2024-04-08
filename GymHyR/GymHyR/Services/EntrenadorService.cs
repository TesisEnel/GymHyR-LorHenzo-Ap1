using GymHyR.Data;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymHyR.Services
{
    public class EntrenadorServices
    {
        private readonly ApplicationDbContext _context;

        public EntrenadorServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entrenador>> GetEntrenadores()
        {
            return await _context.Entrenador.ToListAsync();
        }

        public async Task<Entrenador?> GetEntrenador(int id)
        {
            return await _context.Entrenador.FindAsync(id);
        }

        public async Task<Entrenador> PostEntrenador(Entrenador entrenador)
        {
            _context.Entrenador.Add(entrenador);
            await _context.SaveChangesAsync();
            return entrenador;
        }

        public async Task<IActionResult> PutEntrenador(int id, Entrenador entrenador)
        {
            if (id != entrenador.EntrenadorId)
            {
                return new BadRequestResult();
            }

            _context.Entry(entrenador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntrenadorExists(id))
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

        public async Task DeleteEntrenador(int id)
        {
            var entrenador = await _context.Entrenador.FindAsync(id);

            if (entrenador != null)
            {
                _context.Entrenador.Remove(entrenador);
                await _context.SaveChangesAsync();
            }
        }

        public bool EntrenadorExists(int id)
        {
            return _context.Entrenador.Any(e => e.EntrenadorId == id);
        }
    }
}
