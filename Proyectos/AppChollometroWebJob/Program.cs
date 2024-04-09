using AppChollometroWebJob.Data;
using AppChollometroWebJob.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Bienvenido a Chollos");

string connectionString = @"Data Source=sqlalexiatajamar.database.windows.net;Initial Catalog=AZURETAJAMAR;Persist Security Info=True;User ID=adminsql;Password=Admin123";

//NECESITAMOS UTILIZAR INYECCION DE DEPENDENCIAS
//PARA ELLO DEBEMOS CREAR UN PROVIDER
var provider = new ServiceCollection()
    .AddTransient<RepositoryChollometro>()
    .AddDbContext<ChollometroContext>
    (options => options.UseSqlServer(connectionString))
    .BuildServiceProvider();

//MEDIANTE EL PROVEEDOR, YA PODEMOS RECUPERAR NUESTRO REPOSITORIO
//PARA EJECUTAR EL METODO DE Populate
RepositoryChollometro repo = provider.GetService<RepositoryChollometro>();
Console.WriteLine("Pulse ENTER para iniciar");
Console.ReadLine();
await repo.PopulateChollosAzureAsync();
Console.WriteLine("Proceso completado correctamente");

Console.WriteLine("Fin de las acciones");