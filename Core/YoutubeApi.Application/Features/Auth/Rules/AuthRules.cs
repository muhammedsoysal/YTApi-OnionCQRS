using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Features.Auth.Execptions;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Auth.Rules;

public class AuthRules : BaseRules
{
    public Task UserShouldNotExist(User? user)
    {
        if (user is not null)
            throw new UserAllReadyExistException();
        return Task.CompletedTask;
    }

    public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool checkPassword)
    {
        if (user is null || !checkPassword)
            throw new EmailOrPasswordShouldNotBeInvalid();
        return Task.CompletedTask;
    }

    public Task RefreshTokenShouldNotBeExpired(DateTime expiresDate)
    {
        if (expiresDate <= DateTime.Now)
            throw new RefreshTokenShouldNotBeExpired("Refresh token is expired");
        return Task.CompletedTask;
    }
    public Task EmailAddressShouldBeValid(User user)
    {
        if (user is null)
            throw new EmailAddressShouldBeValid();
        return Task.CompletedTask;
    }

}
