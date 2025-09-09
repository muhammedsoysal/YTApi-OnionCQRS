using YoutubeApi.Domain.Common;

namespace YoutubeApi.Domain.Entities;

public class ProductCategory : IEntityBase
{
    public int ProdctId { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public Product Product { get; set; }
    
}