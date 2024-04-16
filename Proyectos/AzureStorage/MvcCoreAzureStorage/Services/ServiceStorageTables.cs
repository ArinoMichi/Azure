using Azure.Data.Tables;
using MvcCoreAzureStorage.Models;

namespace MvcCoreAzureStorage.Services
{
    public class ServiceStorageTables
    {
        private TableClient tableClient;

        public ServiceStorageTables(TableServiceClient tableService)
        {
            // Inyectamos el Service para crear la tabla
            // en el caso de que no exista
            this.tableClient = tableService.GetTableClient("clientes");
            // ESTAMOS EN UN CONSTRUCTOR Y DICHO METODO DE OBJETO
            // NO PUEDE SER ASINCRONO
            this.tableClient.CreateIfNotExists();
        }

        //METODO PARA CREAR REGISTRO CLIENTE
        public async Task CreateClientAsync(Cliente cli)
        {
            await this.tableClient.AddEntityAsync<Cliente>(cli);
        }
        //METODO PARA BUSCAR CLIENTES POR SU PRIMARY KEY
        //CUANDO HABLAMOS DE ESTE TIPO DE BUSQUEDAS DENTRO
        //DE AZURE STORAGE TABLES, DEBEMOS BUSCAR POR LOS DOS DATOS
        //COMBINADOS, ES DECIR, ROW KEY Y PARTITION KEY
        public async Task<Cliente> FindClienteAsync(string partitionKey, string rowKey)
        {
            Cliente cliente = await this.tableClient.GetEntityAsync<Cliente>(partitionKey, rowKey);
            return cliente;
        }
        //METODO PARA ELIMINAR REGISTROS
        //PARA ELIMINAR UN REGISTRO UNICO, DEBEMOS ENVIAR
        //PARTITION KEY Y ROW KEY
        public async Task DeleteClientAsync(string partitionKey, string rowKey)
        {
            await this.tableClient.DeleteEntityAsync(partitionKey, rowKey);
        }
        //METODO PARA RECUPERAR TODOS LOS REGISTROS
        public async Task<List<Cliente>> GetClientesAsync()
        {
            //PARA PODER RECUPERAR DATOS, AUNQUE SEAN TODOS
            //ES NECESARIO INDICAR UN QUERY CON UN FILTER
            List<Cliente> clientes = new List<Cliente>();
            var query =
                this.tableClient.QueryAsync<Cliente>(filter: "");
            await foreach (var item in query)
            {
                clientes.Add(item);
            }
            return clientes;
        }

        public async Task<List<Cliente>> GetClientesEmpresaAsync(string empresa)
        {
            //PARA FILTRAR, PODEMOS UTILIZAR LA SINTAXIS
            //"PURA" DE TABLES
            //string filtroSalario = "Salario gt 250000";
            //var query =
            //    this.tableClient.QueryAsync<Cliente>(filter: filtroSalario);
            var query =
                this.tableClient.Query<Cliente>(x => x.Empresa == empresa);
            return query.ToList();
        }
    }
}
