using Microsoft.AspNetCore.Identity;
using YoutubeApi.Domain.Common;

namespace YoutubeApi.Domain.Entities;

public class User : IdentityUser<Guid>, IEntityBase
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FullName { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}
