using MediatR;
using Microsoft.AspNetCore.Http;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Features.Products.Queries.GetAllProducts;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Brands.Commands.Queries;

public class GetAllBrandsQueryHandler: BaseHandler , IRequestHandler<GetAllBrandsQueryRequest, IList<GetAllBrandsQueryResponse>>
{
    public GetAllBrandsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public async Task<IList<GetAllBrandsQueryResponse>> Handle(GetAllBrandsQueryRequest request, CancellationToken cancellationToken)
    {
        var brands = await _unitOfWork.GetReadRepository<Brand>().GetAllAsync();
        return   _mapper.Map<GetAllBrandsQueryResponse, Brand>(brands);
    }
}