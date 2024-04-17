using ApiStorageTokens.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ServiceSasToken>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// AQUI SE VAN MAPEANDO LOS DISTINTOS METODOS NECESARIOS
app.MapGet("/testapi", () =>
{
    return "Testing Minimal Api";
});

//QUEREMOS UN METODO PARA GENERAR EL TOKEN Y QUE RECIBA UN CURSO
//LOGICAMENTE PERO NO PODEMOS UTILIZAR LAS PALABRAS 
//RESERVADAS [action] o [controller]
//NECESITAMOS EL SERVICE Y TENEMOS DOS FORMAS DE RECUPERARLO
//1)DENTRO DEL METODO BUSCANDO EL SERVICIO CON Service.GetService<>
//2) UTILIZANDO LA INYECCION
app.MapGet("/token/{curso}", (string curso, ServiceSasToken service) =>
{
    string token = service.GenerateToken(curso);
    return new { token = token };
});

app.Run();

