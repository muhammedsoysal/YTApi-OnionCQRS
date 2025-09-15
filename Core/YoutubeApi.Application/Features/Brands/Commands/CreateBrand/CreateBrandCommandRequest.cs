using MediatR;

namespace YoutubeApi.Application.Features.Brands.Commands;

public class CreateBrandCommandRequest : IRequest<Unit>
{
    public string Name { get; set; }
}