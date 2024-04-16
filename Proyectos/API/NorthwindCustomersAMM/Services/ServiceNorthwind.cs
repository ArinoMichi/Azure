using Newtonsoft.Json;
using NorthwindCustomersAMM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCustomersAMM.Services
{
    public class ServiceNorthwind
    {
        public async Task<CustomersList> GetCustomerListAsync()
        {
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            string url = "https://northwind.netcore.io/customers.json";
            string dataJson = await client.DownloadStringTaskAsync(url);
            CustomersList clientes =
                JsonConvert.DeserializeObject<CustomersList>(dataJson);
            return clientes;
        }
    }
}
