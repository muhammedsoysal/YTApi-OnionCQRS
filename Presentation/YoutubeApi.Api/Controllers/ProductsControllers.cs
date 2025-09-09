using MediatR;
using Microsoft.AspNetCore.Mvc;
using YoutubeApi.Application.Features.Products.Command.CreateProduct;
using YoutubeApi.Application.Features.Products.Command.DeleteProduct;
using YoutubeApi.Application.Features.Products.Command.UpdateProduct;
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

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
    {
        await _mediator.Send(request);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
    {
        try
        {
            await _mediator.Send(request);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
    {
        await _mediator.Send(request);
        return Ok();
    }
}