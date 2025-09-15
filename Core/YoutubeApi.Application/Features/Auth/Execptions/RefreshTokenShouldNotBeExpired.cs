using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Execptions;

public class RefreshTokenShouldNotBeExpired : BaseException
{
    public RefreshTokenShouldNotBeExpired(string v)
        : base("Refresh token is expired") { }
}
