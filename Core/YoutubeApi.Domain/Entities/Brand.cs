using YoutubeApi.Domain.Common;

namespace YoutubeApi.Domain.Entities;

public class Brand: EntityBase
{
    public Brand()
    {
        
    }

    public Brand(string brandName)
    {
        Name = brandName;
    }
    public required string Name { get; set; }
}