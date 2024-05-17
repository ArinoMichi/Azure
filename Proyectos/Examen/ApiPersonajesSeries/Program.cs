using ApiPersonajesSeries.Data;
using ApiPersonajesSeries.Repositories;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAzureClients(factory =>
{
    factory.AddSecretClient(builder.Configuration.GetSection("KeyVault"));
});

//DEBEMOS PODER RECUPERAR UN OBJECTO INYECTADO EN CLASES
//QUE NO TIENEN CONSTRUCTOR
SecretClient secretClient= builder.Services.BuildServiceProvider().GetService<SecretClient>();
KeyVaultSecret secret =
    await secretClient.GetSecretAsync("SqlAzure");

//string connectionString =
//    builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryPersonajesSeries>();
builder.Services.AddDbContext<PersonajesSeriesContext>(options => options.UseSqlServer(secret.Value));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Api Examen Personajes",
        Description = "Api Crud Personajes"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(url: "/swagger/v1/swagger.json",
        name: "Api Crud Personajes");
    options.RoutePrefix = "";
});

if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();