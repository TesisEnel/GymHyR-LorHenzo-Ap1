using GymHyR.DAL;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymHyR.Services
{
    public class ContactosServices(Context context)
    {
        public async Task<IEnumerable<Contactos>> GetContactos()
        {
            return await context.Contactos
            .Select(d => new Contactos()
            {
                ContactoId = d.ContactoId,
                Descripcion = d.Descripcion
            }).ToListAsync();
        }

        public async Task<Contactos?> GetContacto(int id)
        {
            return await context.Contactos.FindAsync(id);
        }

        public async Task<Contactos> PostContactos(Contactos Contactos)
        {
            context.Contactos.Add(Contactos);
            await context.SaveChangesAsync();
            return Contactos;
        }
        public async Task<IActionResult> PutContactos(int id, Contactos Contactos)
        {
            if (id != Contactos.ContactoId)
            {
                return new BadRequestResult();
            }

            context.Entry(Contactos).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactosExists(id))
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

        public async Task DeleteContactos(int id)
        {
            var Contactos = await context.Contactos
                .FirstOrDefaultAsync(p => p.ContactoId == id);

            if (Contactos != null)
            {
                context.Contactos.Remove(Contactos);
                await context.SaveChangesAsync();
            }
        }
        public bool ContactosExists(int id)
        {
            return context.Contactos.Any(e => e.ContactoId == id);
        }
    }
}
