using Azure.Data.Tables;
using Azure.Storage.Blobs;
using MvcCoreAzureStorage.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string azureKeys =
    builder.Configuration.GetValue<string>("AzureKeys:StorageAccount");
BlobServiceClient blobServiceClient = 
    new BlobServiceClient(azureKeys);
builder.Services.AddTransient<BlobServiceClient>(x => blobServiceClient);

TableServiceClient tableServiceClient =
    new TableServiceClient(azureKeys);
builder.Services.AddTransient<TableServiceClient>(x => tableServiceClient);


builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ServiceStorageTables>();
builder.Services.AddTransient<ServiceStorageFiles>();
builder.Services.AddTransient<ServiceStorageBlobs>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AzureFiles}/{action=Index}/{id?}");

app.Run();
