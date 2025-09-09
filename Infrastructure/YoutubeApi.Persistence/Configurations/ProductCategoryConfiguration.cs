using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistence.Configurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasKey(x => new { x.ProdctId, x.CategoryId });
        builder.HasOne(x => x.Product)
            .WithMany(pc => pc.ProductCategories)
            .HasForeignKey(p => p.ProdctId).OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Category)
            .WithMany(cg => cg.ProductCategories)
            .HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.Cascade);

    }
}