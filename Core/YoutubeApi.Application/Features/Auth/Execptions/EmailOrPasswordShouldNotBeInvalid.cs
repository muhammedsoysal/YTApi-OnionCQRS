using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Execptions;

public class EmailOrPasswordShouldNotBeInvalid : BaseException
{
    public EmailOrPasswordShouldNotBeInvalid() : base("Email or password is invalid.")
    {
        
    } 
}