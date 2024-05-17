using ApiPersonajesSeries.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesSeries.Data
{
    public class PersonajesSeriesContext : DbContext
    {
        public PersonajesSeriesContext(DbContextOptions<PersonajesSeriesContext> options) : base(options) { }

        public DbSet<PersonajesSeries> Personajes { get; set; }
    }
}
