using ApiNetCoreHospitales.Data;
using ApiNetCoreHospitales.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string connectionString = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryHospitales>();
builder.Services.AddDbContext<HospitalContext>(options => options.UseSqlServer(connectionString));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Hospitales",
        Description = "API de practica hospitales",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Alexia Tajamar 2024",
            Email = "prueba@mail.com"
        }
    });
});
var app = builder.Build();

app.UseSwagger();
//ESTO TIENE QUE VER CON EL COMPORTAMIENTO DE LA PAGINA SWAGGER
app.UseSwaggerUI(options =>
{
    //INDICAMOS DONDE ESTA EL ENDPOINT DE OPEN API
    options.SwaggerEndpoint(
        url: "/swagger/v1/swagger.json",
        name: "API v1"
        );
    //INDICAMOS QUE INDEX SERA LA PAGINA PRINCIPAL DE NUESTRO API
    options.RoutePrefix = "";
});
if (app.Environment.IsDevelopment())
{

}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
