using Bogus;
using MediatR;
using Microsoft.AspNetCore.Http;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Brands.Commands;

class CreateBrandCommandHandler : BaseHandler, IRequestHandler<CreateBrandCommandRequest, Unit>
{
    public CreateBrandCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    )
        : base(mapper, unitOfWork, httpContextAccessor) { }

    public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
    {
        Faker faker = new Faker("tr");
        List<Brand> brands = new();

        for (int i = 0; i < 1000000; i++)
        {
            brands.Add(new Brand(faker.Commerce.Department()));
        }
        await _unitOfWork.GetWriteRepository<Brand>().AddRangeAsync(brands);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
