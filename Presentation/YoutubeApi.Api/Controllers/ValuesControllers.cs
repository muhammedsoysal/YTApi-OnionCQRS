using Microsoft.AspNetCore.Mvc;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ValuesControllers : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public ValuesControllers(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
     return Ok( await _unitOfWork.GetReadRepository<Product>().GetAllAsync());
    }
    
}