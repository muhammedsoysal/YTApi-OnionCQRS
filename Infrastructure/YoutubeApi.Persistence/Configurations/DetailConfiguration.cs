using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistence.Configurations;

public class DetailConfiguration : IEntityTypeConfiguration<Detail>
{
    public void Configure(EntityTypeBuilder<Detail> builder)
    {
        builder.Property(x => x.Title).HasMaxLength(256);
        builder.Property(x => x.Description).HasMaxLength(256);

        Faker faker = new("tr");
        Detail[] details = new Detail[]
        {
            new Detail { Id = 1, Title = faker.Lorem.Sentence(5), Description = faker.Lorem.Sentence(5), CategoryId = 1 },
            new Detail { Id = 2, Title = faker.Lorem.Sentence(2), Description = faker.Lorem.Sentence(10), CategoryId = 2 },
            new Detail { Id = 3, Title = faker.Lorem.Sentence(3), Description = faker.Lorem.Sentence(15), CategoryId = 3 },
            new Detail { Id = 4, Title = faker.Lorem.Sentence(4), Description = faker.Lorem.Sentence(20), CategoryId = 4 ,IsDeleted=true},

        };
        builder.HasData(details);
    }
}
