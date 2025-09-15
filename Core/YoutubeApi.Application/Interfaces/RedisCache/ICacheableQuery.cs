namespace YoutubeApi.Application.Interfaces.RedisCache;

public class ICacheableQuery
{
   public string CacheKey { get; set; }
   public   double CacheTime { get; set; }
}