using MediatR;
using Microsoft.AspNetCore.Mvc;
using YoutubeApi.Application.Features.Products.Queries.GetAllProducts;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ProductsControllers : Controller
{
    IMediator _mediator;
    
    public ProductsControllers(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProductsAsync()
    {
        var response = await _mediator.Send(new GetAllProductsQueryRequest());
        return Ok(response);
    }
    
}