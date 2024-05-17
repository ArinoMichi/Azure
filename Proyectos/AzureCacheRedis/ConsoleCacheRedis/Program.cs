using ConsoleCacheRedis;

ServiceCacheRedis servide = new ServiceCacheRedis();
List<Producto> favoritos = 
    await servide.GetProductosFavoritosAsync();
if (favoritos == null)
{
    Console.WriteLine("No hay favoritos");
}
else
{
    int i = 1;
    foreach(Producto producto in favoritos)
    {
        Console.WriteLine(i + " - " + producto.Nombre);
        i++;
    }
}
Console.WriteLine("Final del programa");
