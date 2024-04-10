using ApiCrudCoreDoctores.Models;
using ApiCrudCoreDoctores.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudCoreDoctores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        private RepositoryDoctores repo;

        public DoctoresController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>>GetDoctores()
        {
            return await this.repo.GetDoctoresAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> FindDoctor(int id)
        {
            return await this.repo.FindDoctorAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult> PostDoctor(Doctor doctor)
        {
            await this.repo.InsertDoctorAsync(doctor);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            //PODEMOS PERSONALIZAR LA RESPUESTA
            if (await this.repo.FindDoctorAsync(id) == null)
            {
                //NO EXISTE EL DEPARTAMENTO PARA ELIMINARLO
                return NotFound();
            }
            else
            {
                await this.repo.DeleteDoctorAsync(id);
                return Ok();
            }

        }
        [HttpPut]
        public async Task<ActionResult> PutDepartamento
            (Doctor doctor)
        {
            await this.repo.UpdateDoctorAsync(doctor);
            return Ok();
        }



    }
}
