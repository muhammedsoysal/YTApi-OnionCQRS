using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Execptions;

public class EmailAddressShouldBeValid : BaseException
{
    public EmailAddressShouldBeValid() : base("Email address is not valid")
    {
    }
}