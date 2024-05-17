using ApiPersonajesSeries.Data;
using ApiPersonajesSeries.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesSeries.Repositories
{
    public class RepositoryPersonajesSeries
    {
        private PersonajesSeriesContext context;

        public RepositoryPersonajesSeries(PersonajesSeriesContext context)
        {
            this.context = context;
        }

        public async Task<List<PersonajesSeries>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<List<PersonajesSeries>> GetPersonajesSerieAsync(string serie)
        {
            return await this.context.Personajes.Where(z => z.Serie == serie).ToListAsync();
        }

        public async Task<List<string>> GetSeriesAsync()
        {
            return await this.context.Personajes.Select(z => z.Serie).Distinct().ToListAsync();
        }

        public async Task<PersonajesSeries> GetPersonajeIdAsync(int id)
        {
            return await this.context.Personajes.Where(x => x.IdPersonaje==id).FirstOrDefaultAsync();
        }

        public async Task InsertPersonaje(PersonajesSeries personaje)
        {
            this.context.Add(personaje);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdatePersonaje(PersonajesSeries personaje)
        {
            PersonajesSeries pj = await this.context.Personajes.Where(x => x.IdPersonaje == personaje.IdPersonaje).FirstOrDefaultAsync();
            if (pj != null)
            {
                pj.Serie = personaje.Serie;
                pj.Nombre = personaje.Nombre;
                pj.Imagen = personaje.Imagen;
            }
            await this.context.SaveChangesAsync();
        }
        public async Task DeletePersonaje(int idPersonaje)
        {
            PersonajesSeries pj = await this.context.Personajes.Where(x => x.IdPersonaje == idPersonaje).FirstOrDefaultAsync();
            this.context.Remove(pj);
            await this.context.SaveChangesAsync();
        }

    }
}
