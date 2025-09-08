using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistence.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(256);

        Faker faker = new("tr");
        Brand[] brands = new Brand[]
        {
            new Brand { Id = 1, Name = faker.Commerce.ProductName() ,IsDeleted=false},
            new Brand { Id = 2, Name = faker.Commerce.ProductName() ,IsDeleted=false},
            new Brand { Id = 3, Name = faker.Commerce.ProductName() ,IsDeleted=false},
			new Brand { Id = 4, Name = faker.Commerce.ProductName(), IsDeleted=true},
        };

        builder.HasData(brands);
    }
}
