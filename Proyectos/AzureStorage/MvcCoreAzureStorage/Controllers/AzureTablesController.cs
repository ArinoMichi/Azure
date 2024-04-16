using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using MvcCoreAzureStorage.Models;
using MvcCoreAzureStorage.Services;

namespace MvcCoreAzureStorage.Controllers
{
    public class AzureTablesController : Controller
    {
        private ServiceStorageTables service;

        public AzureTablesController(ServiceStorageTables service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Cliente> clientes = await this.service.GetClientesAsync();
            return View(clientes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Cliente cli)
        {
            await this.service.CreateClientAsync(cli);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string partitionkey, string rowkey)
        {
            await this.service.DeleteClientAsync(partitionkey, rowkey);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string partitionkey, string rowkey)
        {
            Cliente cli = await this.service.FindClienteAsync(partitionkey, rowkey);
            return View(cli);
        }

        public IActionResult ClientesEmpresa()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ClientesEmpresa(string empresa)
        {
            List<Cliente> clientes = await this.service.GetClientesEmpresaAsync(empresa);
            return View(clientes);
        }

    }
}
