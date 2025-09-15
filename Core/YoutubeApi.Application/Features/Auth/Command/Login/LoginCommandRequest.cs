using System.ComponentModel;
using MediatR;

namespace YoutubeApi.Application.Features.Auth.Command.Login;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
    [DefaultValue("admin@gmail.com")]
    public string Email { get; set; }
    [DefaultValue("admin12")]
    public string Password { get; set; }
}