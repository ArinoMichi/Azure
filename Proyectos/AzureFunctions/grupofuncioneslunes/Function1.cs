using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace grupofuncioneslunes
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("functionlikeempleado")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            // VAMOS A PEDIR UN PAR�METRO
            var query = System.Web.HttpUtility.ParseQueryString(req.Url.Query);
            string idempleado = query["idempleado"];
            if(idempleado == null)
            {
                var responsebad = req.CreateResponse(HttpStatusCode.BadRequest);
                responsebad.WriteString("Debe proporcionar un ID de Empleado");
                return responsebad;
            }

            _logger.LogInformation(idempleado);


            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            //CADENA DE CONEXION
            string connectionString =
                Environment.GetEnvironmentVariable("SqlAzure");

            //string connectionString = "Data Source=sqlalexiatajamar.database.windows.net;Initial Catalog=AZURETAJAMAR;Persist Security Info=True;User ID=adminsql;Password=Admin123;Encrypt=False";
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand();
            string sqlUpdate = "UPDATE EMP SET SALARIO = SALARIO + 1" +
                "WHERE EMP_NO=" + idempleado;
            com.Connection = cn;
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = sqlUpdate;
            cn.Open();
            com.ExecuteNonQuery();
            string sqlSelect = "select * from EMP where EMP_NO=" + idempleado;
            com.CommandText = sqlSelect;
            SqlDataReader reader = com.ExecuteReader();
            string mensaje = "";
            if(reader.Read())
            {
                mensaje = "El empleado " + reader["APELLIDO"].ToString() + " con oficio" +
                    reader["OFICIO"].ToString() + " ha incrementado su salario a " + reader["SALARIO"].ToString();
                reader.Close();
            }
            else
            {
                mensaje = "No existe el empleado con ID " + idempleado;
            }
            cn.Close();

            response.WriteString(mensaje);

            return response;
        }
    }
}
