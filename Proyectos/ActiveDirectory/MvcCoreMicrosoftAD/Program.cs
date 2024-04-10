using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcCoreMicrosoftAD.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString =
    builder.Configuration.GetConnectionString("SqlLocal");
string appId =
    builder.Configuration.GetValue<string>
    ("Authentication:Microsoft:ApplicationID");
string secretKey =
    builder.Configuration.GetValue<string>
    ("Authentication:Microsoft:SecretKey");
builder.Services.AddDbContext<ApplicationContext>
    (options => options.UseSqlServer(connectionString));
//INDICAMOS QUE UTILIZAREMOS UN USUARIO IdentityUser
//DENTRO DE NUESTRA APP Y QUE LO ADMINISTRARA NUESTRO CONTEXT
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationContext>();
//SI QUEREMOS UTILIZAR DISTINTOS PROVEEDORES ES AQUI DONDE 
//LOS IREMOS DANDO DE ALTA
builder.Services.AddAuthentication().AddMicrosoftAccount(options =>
{
    options.ClientId = appId;
    options.ClientSecret = secretKey;
});

//COMO VAMOS A UTILIZAR RUTAS PERSONALIZADAS
builder.Services.AddControllersWithViews
    (options => options.EnableEndpointRouting = false);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}");
});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
