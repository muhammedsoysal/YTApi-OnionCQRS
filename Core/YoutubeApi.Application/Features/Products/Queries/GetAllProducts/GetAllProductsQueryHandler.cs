using MediatR;
using Microsoft.EntityFrameworkCore;
using YoutubeApi.Application.DTOs;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler
    : IRequestHandler<GetAllProductsQueryRequest, PagedResult<GetAllProductsQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PagedResult<GetAllProductsQueryResponse>> Handle(
        GetAllProductsQueryRequest request,
        CancellationToken cancellationToken
    )
    {
        var (products, totalCount) = await _unitOfWork
            .GetReadRepository<Product>()
            .GetPagedAsync(
                include: x => x.Include(b => b.Brand),
                currentPage: request.Page,
                pageSize: request.PageSize
            );

        var mappedProducts = products
            .Select(p => new GetAllProductsQueryResponse
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price,
                Discount = p.Discount,
                Brand = p.Brand?.Name ?? "Unknown",
            })
            .ToList();

        // Discount hesaplaması
        foreach (var item in mappedProducts)
        {
            item.Price -= (item.Price * item.Discount / 100);
        }

        return new PagedResult<GetAllProductsQueryResponse>(
            mappedProducts,
            request.Page,
            request.PageSize,
            totalCount
        );
    }
}
