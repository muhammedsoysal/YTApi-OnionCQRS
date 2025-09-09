using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Title).HasMaxLength(256);
        builder.Property(x => x.Description).HasMaxLength(256);
        builder.Property(x => x.Price).HasPrecision(18, 2);
        builder.Property(x => x.Discount).HasPrecision(5, 2);

        Faker faker = new("tr");
        Product[] products = new Product[]
        {
            new Product(title: faker.Commerce.ProductName(), description: faker.Commerce.ProductDescription(),
                price: faker.Finance.Amount(10, 1000), discount: faker.Random.Decimal(10, 100), brandId: 1)
            { Id = -1 },
            new Product
            {
                Id = -2,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                Price = faker.Finance.Amount(100, 1000),
                Discount = faker.Random.Decimal(10, 100),
                BrandId = 2,
            },
            new Product
            {
                Id = -3,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                Price = faker.Finance.Amount(100, 1000),
                Discount = faker.Random.Decimal(10, 100),
                BrandId = 3,
            },
        };
        builder.HasData(products);
    }
}
