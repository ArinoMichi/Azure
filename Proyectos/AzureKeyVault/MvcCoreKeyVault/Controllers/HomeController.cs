using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;
using MvcCoreKeyVault.Models;
using System.Diagnostics;

namespace MvcCoreKeyVault.Controllers
{
    public class HomeController : Controller
    {
        //NECESITAMOS INYECTAR SECRETCLIENT
        private SecretClient secretClient;

        public HomeController(SecretClient secretClient)
        {
            this.secretClient = secretClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string secretKey)
        {
            KeyVaultSecret keyVault =
                await this.secretClient.GetSecretAsync(secretKey);
            ViewData["SECRETO"] = keyVault.Value;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}