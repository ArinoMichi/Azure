using Microsoft.AspNetCore.Mvc;
using MvcCoreChollometro.Models;
using MvcCoreChollometro.Repositories;

namespace MvcCoreChollometro.Controllers
{
    public class ChollosController : Controller
    {
        private RepositoryChollometro repo;

        public ChollosController(RepositoryChollometro repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Chollo> chollos = await this.repo.GetChollosAsync();
            return View(chollos);
        }
    }
}
