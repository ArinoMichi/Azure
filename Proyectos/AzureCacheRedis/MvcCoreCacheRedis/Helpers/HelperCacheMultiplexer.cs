using StackExchange.Redis;

namespace MvcCoreCacheRedis.Helpers
{
    public class HelperCacheMultiplexer
    {
        private static Lazy<ConnectionMultiplexer>
      CreateConnection = new Lazy<ConnectionMultiplexer>(() =>
      {
          string cacheRedisKeys = "cacheredisalexia.redis.cache.windows.net:6380,password=Xd7syVn99VxJaSiMYjNHlTu3KsMffwCK4AzCaMgiQjc=,ssl=True,abortConnect=False";
          return ConnectionMultiplexer.Connect(cacheRedisKeys);
      });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return CreateConnection.Value;
            }
        }
    }
}
