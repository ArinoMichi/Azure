using ApiCorePersonas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCorePersonas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        List<Persona> personas;

        public PersonasController()
        {
            this.personas = new List<Persona>();
            Persona p = new Persona
            { IdPersona = 1, Nombre = "Alumno", Email = "alumno@mail.com", Edad = 22 };
            this.personas.Add(p);
            p = new Persona
            { IdPersona = 2, Nombre = "Lucia", Email = "lucia@mail.com", Edad = 20 };
            this.personas.Add(p);
            p = new Persona
            { IdPersona = 3, Nombre = "Adrian", Email = "adrian@mail.com", Edad = 25 };
            this.personas.Add(p);
            p = new Persona
            { IdPersona = 4, Nombre = "Pedro", Email = "pedro@mail.com", Edad = 45 };
            this.personas.Add(p);
        }

        [HttpGet]
        public ActionResult<List<Persona>> Get()
        {
            return this.personas;
        }
        //METODO PARA BUSCAR UNA PERSONA
        //DEBEMOS INDICAR EN LA PETICION GET QUE UTILIZARA 
        //EL PARAMETRO POR DEFECTO id PARA EL METODO
        //LOS PARAMETROS SE REPRESENTAN CON {param}
        [HttpGet("{id}")]
        public ActionResult<Persona> FindPersona(int id)
        {
            return this.personas.FirstOrDefault(x => x.IdPersona == id);
        }

    }
}
