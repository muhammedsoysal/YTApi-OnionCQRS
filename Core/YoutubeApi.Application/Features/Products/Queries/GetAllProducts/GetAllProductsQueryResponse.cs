using YoutubeApi.Application.DTOs;

namespace YoutubeApi.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public string Brand { get; set; } // Brand adını string olarak tutuyoruz
}