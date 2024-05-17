using MvcPersonajesSeries.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MvcPersonajesSeries.Services
{
    public class ServicePersonajes
    {
        private string urlApi;
        private MediaTypeWithQualityHeaderValue header;

        public ServicePersonajes(IConfiguration configuration)
        {
            this.urlApi = configuration.GetValue<string>("ApiUrls:ApiPersonajes");
            this.header =
                new MediaTypeWithQualityHeaderValue("application/json");
        }
        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.urlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<PersonajesSeries>> GetPersonajesAsync()
        {
            string request = "api/Personajes";
            List<PersonajesSeries> data =
                await this.CallApiAsync<List<PersonajesSeries>>(request);
            return data;
        }

       

        public async Task<List<PersonajesSeries>> GetPersonajesSerieAsync(string serie)
        {
            string request = "api/Personajes/PersonajesSeries/" + serie;
            List<PersonajesSeries> data =
                await this.CallApiAsync<List<PersonajesSeries>>(request);
            return data;
        }
        public async Task<List<string>> GetSeriesAsync()
        {
            string request = "api/Personajes/Series";
            List<string> data =
                await this.CallApiAsync<List<string>>(request);
            return data;
        }

        public async Task<PersonajesSeries> GetPersonajeIdAsync(int id)
        {
            string request = "api/Personajes/" + id;
            PersonajesSeries data =
                await this.CallApiAsync<PersonajesSeries>(request);
            return data;
        }

        public async Task DeletePersonajeAsync(int idPersonaje)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/Personajes/DeletePersonaje/" + idPersonaje;
                client.BaseAddress = new Uri(this.urlApi);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage response =
                    await client.DeleteAsync(request);
            }
        }
        public async Task InsertPersonajeAsync(PersonajesSeries personaje)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/Personajes/InsertPersonaje";
                client.BaseAddress = new Uri(this.urlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);

                string json = JsonConvert.SerializeObject(personaje);
                StringContent content = new StringContent
                    (json, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PostAsync(request, content);
            }
        }
        public async Task UpdatePersonajeAsync(PersonajesSeries personaje)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/Personajes/UpdatePersonaje";
                client.BaseAddress = new Uri(this.urlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);

                string json = JsonConvert.SerializeObject(personaje);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
            }
        }



    }
}
