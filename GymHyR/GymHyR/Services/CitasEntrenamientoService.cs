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
    public class CitasEntrenamientoService
    {
        private readonly ApplicationDbContext _context;

        public CitasEntrenamientoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CitasEntrenamiento>> GetCitasEntrenamiento()
        {
            return await _context.CitasEntrenamiento.ToListAsync();
        }

        public async Task<CitasEntrenamiento?> GetCitaEntrenamiento(int id)
        {
            return await _context.CitasEntrenamiento.FindAsync(id);
        }

        public async Task<CitasEntrenamiento> PostCitaEntrenamiento(CitasEntrenamiento cita)
        {
            _context.CitasEntrenamiento.Add(cita);
            await _context.SaveChangesAsync();
            return cita;
        }

        public async Task<IActionResult> PutCitaEntrenamiento(int id, CitasEntrenamiento cita)
        {
            if (id != cita.CitasEntrenamientoId)
            {
                return new BadRequestResult();
            }

            _context.Entry(cita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaEntrenamientoExists(id))
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

        public async Task DeleteCitaEntrenamiento(int id)
        {
            var cita = await _context.CitasEntrenamiento.FindAsync(id);

            if (cita != null)
            {
                _context.CitasEntrenamiento.Remove(cita);
                await _context.SaveChangesAsync();
            }
        }

        public bool CitaEntrenamientoExists(int id)
        {
            return _context.CitasEntrenamiento.Any(e => e.CitasEntrenamientoId == id);
        }
    }
}
