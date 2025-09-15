using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YoutubeApi.Application.Features.Brands.Commands;
using YoutubeApi.Application.Features.Brands.Commands.Queries;

namespace YoutubeApi.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
//[Authorize]
public class BrandsController : Controller
{
    private readonly IMediator _mediator;

    public BrandsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBrands()
    {
        var response = await _mediator.Send(new GetAllBrandsQueryRequest());
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandCommandRequest request)
    {
        await _mediator.Send(request);
        return Ok();
    }
}
