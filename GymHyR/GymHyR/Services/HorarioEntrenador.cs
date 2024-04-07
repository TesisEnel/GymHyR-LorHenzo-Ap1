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
    public class HorarioEntrenadorService
    {
        private readonly ApplicationDbContext _context;

        public HorarioEntrenadorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HorarioEntrenador>> GetHorariosEntrenador()
        {
            return await _context.HorarioEntrenador.ToListAsync();
        }

        public async Task<HorarioEntrenador?> GetHorarioEntrenador(int id)
        {
            return await _context.HorarioEntrenador.FindAsync(id);
        }

        public async Task<HorarioEntrenador> PostHorarioEntrenador(HorarioEntrenador horario)
        {
            _context.HorarioEntrenador.Add(horario);
            await _context.SaveChangesAsync();
            return horario;
        }

        public async Task<IActionResult> PutHorarioEntrenador(int id, HorarioEntrenador horario)
        {
            if (id != horario.HorarioEntrenadorId)
            {
                return new BadRequestResult();
            }

            _context.Entry(horario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorarioEntrenadorExists(id))
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

        public async Task DeleteHorarioEntrenador(int id)
        {
            var horario = await _context.HorarioEntrenador.FindAsync(id);

            if (horario != null)
            {
                _context.HorarioEntrenador.Remove(horario);
                await _context.SaveChangesAsync();
            }
        }

        public bool HorarioEntrenadorExists(int id)
        {
            return _context.HorarioEntrenador.Any(e => e.HorarioEntrenadorId == id);
        }
    }
}
