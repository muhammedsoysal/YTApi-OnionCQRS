using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Products.Command.UpdateProduct;

public class UpdateProductCommandHandler : BaseHandler,IRequestHandler<UpdateProductCommandRequest, Unit>
{

    public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        : base(mapper, unitOfWork, httpContextAccessor) { }

    public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork
            .GetReadRepository<Product>()
            .GetAsync(x => x.Id == request.Id && !x.IsDeleted);

        var map = _mapper.Map<Product, UpdateProductCommandRequest>(request);
        map.Id = request.Id;

        var productCategories = await _unitOfWork
            .GetReadRepository<ProductCategory>()
            .GetAllAsync(x => x.ProdctId == request.Id);

        if (productCategories is not null && productCategories.Count > 0)
            await _unitOfWork.GetWriteRepository<ProductCategory>().HardDeleteRangeAsync(productCategories);

        if (request.CategoryIds is not null)
        {
            foreach (var categoryId in request.CategoryIds)
            {
                await _unitOfWork
                    .GetWriteRepository<ProductCategory>()
                    .AddAsync(new() { CategoryId = categoryId, ProdctId = request.Id });
            }
        }

        await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
