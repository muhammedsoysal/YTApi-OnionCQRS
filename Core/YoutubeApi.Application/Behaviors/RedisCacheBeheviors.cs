using MediatR;
using YoutubeApi.Application.Interfaces.RedisCache;

namespace YoutubeApi.Application.Behaviors;

public class RedisCacheBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IRedisCacheService _redisCacheService;

    public RedisCacheBehaviors(IRedisCacheService redisCacheService)
    {
        _redisCacheService = redisCacheService;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        if (request is ICacheableQuery query)
        {
            var cacheKey = query.CacheKey;
            var cacheTime = query.CacheTime;

            var cacheDate = await _redisCacheService.GetAsync<TResponse>(cacheKey);
            if (cacheDate is not null)
                return cacheDate;
            var response = await next();
            if (response is not null)
                await _redisCacheService.SetAsync(
                    cacheKey,
                    response,
                    DateTime.Now.AddMinutes(cacheTime)
                );
            return response;
        }
        return await next();
    }
}
