using MvcCoreCacheRedis.Helpers;
using MvcCoreCacheRedis.Models;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MvcCoreCacheRedis.Services
{
    public class ServiceCacheRedis
    {
        private IDatabase database;

        public ServiceCacheRedis()
        {
            this.database =
                HelperCacheMultiplexer.Connection.GetDatabase();
        }

        //METODO PARA ALMACENAR PRODUCTOS
        public async Task AddProductoFavorito(Producto producto)
        {
            //CACHE REDIS FUNCIONA CON KEY/VALUE
            //DICHAS CLAVES SON COMUNES PARA TODOS LOS USUARIOS
            //DEBERIAMOS TENER UNA CLAVE UNICA PARA CADA USER
            //VAMOS A ALMACENAR EL PRODUCTO CON FORMATO JSON
            //LO QUE TENDREMOS EN CACHE REDIS SERA UNA COLECCION
            //DE TODOS LOS PRODUCTOS
            string jsonProductos = await this.database.StringGetAsync("favoritos");
            List<Producto> productosList;
            if(jsonProductos == null)
            {
                //NO TENEMOS FAVORITOS TODAVIA, CREAMOS LA COLECCION
                productosList = new List<Producto>();
            }
            else
            {
                //YA TENEMOS FAVORITOS EN CACHE Y LOS RECUPERAMOS
                productosList = 
                    JsonConvert.DeserializeObject<List<Producto>>(jsonProductos);
            }
            //INCLUIMOS EL NUEVO PRODUCTO 
            productosList.Add(producto);
            //SERIALIZAMOS LA COLECCION CON LOS NUEVOS DATOS 
            jsonProductos= JsonConvert.SerializeObject(productosList);
            //ALMACENAMOS LOS NUEVOS DATOS EN AZURE CACHE REDIS
            await this.database.StringSetAsync("favoritos", jsonProductos);
        }

        //METODO PARA RECUPERAR TODOS LOD PRODUCTOS
        public async Task<List<Producto>> GetProductosFavoritosAsync()
        {
            string jsonProductos = await
                this.database.StringGetAsync("favoritos");
            if(jsonProductos == null)
            {
                return null;
            }
            else
            {
                List<Producto> favoritos = 
                    JsonConvert.DeserializeObject<List<Producto>>(jsonProductos);
                return favoritos;
            }
            
        }

        //METODO PARA ELIMINAR PRODUCTOS DE FAVORITOS
        public async Task DeleteProductoFavoritoAsync(int idproducto)
        {
            //ESTO NO ES UNA BASE DE DATOS, NO PODEMOS FILTRAR
            List<Producto> favoritos =
                await this.GetProductosFavoritosAsync();
            if(favoritos != null)
            {
                //BUSCAMOS EL PRODUCTO
                Producto productoDelete =
                    favoritos.FirstOrDefault(x => x.IdProducto == idproducto);
                //ELIMINAMOS EL PRODUCTO DE LA COLECCION
                favoritos.Remove(productoDelete);
                //TENEMOS QUE COMPROBAR SI TODAVIA
                //TENEMOS ALGUN FAVORITO
                if(favoritos.Count == 0)
                {
                    //SI YA NO TENEMOS FAVORITOS ELIMINAMOS
                    //LA KEY DE AZURE CACHE REDIS
                    await this.database.KeyDeleteAsync("favoritos");
                }
                else
                {
                    //ALMACENAMOS LOS PRODUCTOS FAVORITOS DE NUEVO
                    string jsonProductos =
                        JsonConvert.SerializeObject(favoritos);
                    //PODEMOS INDICAR POR CODIGO EL TIEMPO DE 
                    //DURACION DE LA KEY DENTRO DE CACHE REDIS.
                    //SI NO LE DIGO NADA, EL TIEMPO PREDETERMINADO
                    //ES DE 24 HORAS
                    await this.database.StringSetAsync("favoritos",jsonProductos, TimeSpan.FromMinutes(30));
                }
            }
        }

    }
}
