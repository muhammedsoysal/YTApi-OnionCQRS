

using MediatR;
using YoutubeApi.Application.Features.Products.Queries.GetAllProducts;
using YoutubeApi.Application.Interfaces.RedisCache;

namespace YoutubeApi.Application.Features.Brands.Commands.Queries;

public class GetAllBrandsQueryRequest : ICacheableQuery,IRequest<IList<GetAllBrandsQueryResponse>>
{
    public string CacheKey => "GetAllBrands";
    public double CacheTime => 5;
}
