﻿using ApiEmpleadosMultiplesRoutes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetApiModels.Models;

namespace ApiEmpleadosMultiplesRoutes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Empleado>>>
            GetEmpleados()
        {
            return await this.repo.GetEmpleadosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>>
            FindEmpleado(int id)
        {
            return await this.repo.FindEmpleadoAsync(id);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<string>>> Oficios()
        {
            return await this.repo.GetOficiosAsync();
        }
        [HttpGet]
        [Route("[action]/{oficio}")]
        public async Task<ActionResult<List<Empleado>>>
     EmpleadosOficio(string oficio)
        {
            return await this.repo.GetEmpleadosOficioAsync(oficio);
        }

        //LOS PARAMETROS DEBEN TENER EL MISMO NOMBRE
        //DEBEN ESTAR EN EL MISMO ORDEN QUE RECIBE EL METODO
        [HttpGet]
        [Route("[action]/{salario}/{departamento}")]
        public async Task<ActionResult<List<Empleado>>> EmpleadosSalario(int salario, int departamento)
        {
            return await this.repo.GetEmpleadosSalarioAsync(salario, departamento);
        }
    }
}
