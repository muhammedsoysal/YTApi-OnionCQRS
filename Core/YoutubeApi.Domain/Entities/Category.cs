using YoutubeApi.Domain.Common;

namespace YoutubeApi.Domain.Entities;

public class Category : EntityBase, IEntityBase
{
    public Category() {}
    public Category(int parentId, string name, int priority)
    {
        ParentId = parentId;
        Name = name;
        Priority = priority;
    }

    public required int ParentId { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required int Priority { get; set; }
    public ICollection<Detail> Details { get; set; }
    public ICollection<Product> Products { get; set; }
}
