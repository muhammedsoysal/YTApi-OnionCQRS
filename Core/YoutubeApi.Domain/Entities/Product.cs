using YoutubeApi.Domain.Common;

namespace YoutubeApi.Domain.Entities;

public class Product : EntityBase
{
    public Product() { }


    public required string Title { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required decimal Discount { get; set; }
    public required int BrandId { get; set; }
    public Brand Brand { get; set; }
    public ICollection<Category> Categories { get; set; }
}
