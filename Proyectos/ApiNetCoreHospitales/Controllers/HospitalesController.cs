using ApiNetCoreHospitales.Models;
using ApiNetCoreHospitales.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNetCoreHospitales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalesController : ControllerBase
    {
        private RepositoryHospitales repo;
        public HospitalesController(RepositoryHospitales repo)
        {
            this.repo = repo;
        }
        //LOS NOMBRESDE METODOS EN LOS METODOS POR DEFECTO
        //NO IMPORTAN. AUN ASI, SEGUIMOS LAS MISMAS NORMAS DE
        //NO INCLUIR LA PALABRA ASYNC DENTRO DEL METODO
        //DE UN CONTROLLER
        [HttpGet]
        public async Task<ActionResult<List<Hospital>>> GetHospitales()
        {
            return await this.repo.GetHospitalesAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Hospital>> FindHospital(int id)
        {
            return await this.repo.FindHospitalAsync(id);
        }

    }
}
