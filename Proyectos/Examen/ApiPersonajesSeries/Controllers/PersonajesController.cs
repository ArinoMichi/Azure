using ApiPersonajesSeries.Models;
using ApiPersonajesSeries.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesSeries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajesSeries repo;

        public PersonajesController(RepositoryPersonajesSeries repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonajesSeries>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }
        [HttpGet]
        [Route("PersonajesSeries/{serie}")]
        public async Task<ActionResult<List<PersonajesSeries>>> GetPersonajesSerie(string serie)
        {
            return await this.repo.GetPersonajesSerieAsync(serie);
        }
        [HttpGet]
        [Route("Series")]
        public async Task<ActionResult<List<string>>> GetSeries()
        {
            return await this.repo.GetSeriesAsync();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PersonajesSeries>> GetPersonajeId(int id)
        {
            return await this.repo.GetPersonajeIdAsync(id);
        }
        [HttpPost]
        [Route("InsertPersonaje")]
        public async Task<ActionResult> InsertPersonaje(PersonajesSeries personaje)
        {
            await this.repo.InsertPersonaje(personaje);
            return Ok();
        }
        [HttpPut]
        [Route("UpdatePersonaje")]
        public async Task<ActionResult> UpdatePersonaje(PersonajesSeries personaje)
        {
            await this.repo.UpdatePersonaje(personaje);
            return Ok();
        }
        [HttpDelete]
        [Route("DeletePersonaje/{id}")]
        public async Task<ActionResult> DeletePersonaje(int id)
        {
            await this.repo.DeletePersonaje(id);
            return Ok();
        }


    }
}
