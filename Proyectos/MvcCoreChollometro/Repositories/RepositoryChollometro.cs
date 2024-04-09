using Microsoft.EntityFrameworkCore;
using MvcCoreChollometro.Data;
using MvcCoreChollometro.Models;

namespace MvcCoreChollometro.Repositories
{
    public class RepositoryChollometro
    {
        private ChollometroContext context;

        public RepositoryChollometro(ChollometroContext context)
        {
            this.context = context;
        }

        public async Task<List<Chollo>> GetChollosAsync()
        {
            return await context.Chollos.OrderByDescending(chollo => chollo.Fecha).ToListAsync();
        }
    }
}
