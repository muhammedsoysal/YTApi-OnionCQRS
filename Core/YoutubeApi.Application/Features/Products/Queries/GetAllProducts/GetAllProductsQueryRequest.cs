using MediatR;
using YoutubeApi.Application.DTOs;

namespace YoutubeApi.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryRequest : IRequest<PagedResult<GetAllProductsQueryResponse>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}