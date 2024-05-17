using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MvcCoreLogicApps.Services
{
    public class ServiceLogicApps
    {
        private MediaTypeWithQualityHeaderValue header;

        public ServiceLogicApps()
        {
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task SendEmailAsync(string email,string asunto,string mensaje)
        {
            string urlLogicApp = "https://prod-32.westeurope.logic.azure.com:443/workflows/3c123c81ea2e4f5bac688b7876b3047a/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=1.0&sig=7rLzljIwy4uo_aiQvZGw5-R9wJ5EFKJ0FkaS5FQwj8o";
            var model = new
            {
                email = email,
                asunto = asunto,
                mensaje = mensaje
            };
            using(HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                string json = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(json,Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlLogicApp, content);
            }

        }
    }
}
