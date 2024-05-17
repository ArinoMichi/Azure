using Microsoft.AspNetCore.Mvc;
using MvcPersonajesSeries.Models;
using MvcPersonajesSeries.Services;

namespace MvcPersonajesSeries.Controllers
{
    public class PersonajesController : Controller
    {
        private ServicePersonajes service;

        public PersonajesController(ServicePersonajes service)
        {
            this.service = service;
        }
        public IActionResult Series()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Series(string serie)
        {
            List<PersonajesSeries> personajes = await this.service.GetPersonajesSerieAsync(serie);
            return View(personajes);
        }

        public async Task<IActionResult> Home()
        {
            List<PersonajesSeries> personajes = await this.service.GetPersonajesAsync();
            return View(personajes);
        }

        public async Task<IActionResult> Details(int id)
        {
            PersonajesSeries personaje = await this.service.GetPersonajeIdAsync(id);
            return View(personaje);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PersonajesSeries personaje)
        {
            await this.service.InsertPersonajeAsync(personaje);
            return RedirectToAction("Home");
        }
        public async Task<IActionResult> Edit(int id)
        {
            PersonajesSeries personaje = await this.service.GetPersonajeIdAsync(id);
            return View(personaje);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PersonajesSeries personaje)
        {
            await this.service.UpdatePersonajeAsync(personaje);
            return RedirectToAction("Home");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.service.DeletePersonajeAsync(id);
            return RedirectToAction("Home");

        }
    }
}
