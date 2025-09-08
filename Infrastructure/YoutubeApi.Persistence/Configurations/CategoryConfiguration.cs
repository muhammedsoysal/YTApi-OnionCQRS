using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(256);

        Faker faker = new("tr");
        Category[] categories = new Category[]
        {
            new Category { Id = 1, Name = "Elektronik" ,IsDeleted=false,Priority=1,ParentId=0},
			new Category { Id = 2, Name = "Moda" ,IsDeleted=false,Priority=1,ParentId=0},
			new Category { Id = 3, Name = "Bilgisayar" ,IsDeleted=false,Priority=1,ParentId=1},
			new Category { Id = 4, Name = "Kadın Giyim" ,IsDeleted=false,Priority=1,ParentId=2},
        };
        builder.HasData(categories);
    }
}
