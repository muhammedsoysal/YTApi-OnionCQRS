using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Execptions;

public class UserAllReadyExistException: BaseException
{
    public UserAllReadyExistException(): base("User allready exist."){}
}