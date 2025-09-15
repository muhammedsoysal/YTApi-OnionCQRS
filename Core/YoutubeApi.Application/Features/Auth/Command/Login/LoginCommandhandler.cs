using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Features.Auth.Rules;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.Interfaces.Tokens;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Auth.Command.Login;

public class LoginCommandhandler
    : BaseHandler,
        IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly AuthRules _authRules;
    private readonly IConfiguration _configuration;

    public LoginCommandhandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        UserManager<User> userManager,
        AuthRules authRules,
        RoleManager<Role> roleManager,
        ITokenService tokenService,
        IConfiguration configuration
    )
        : base(mapper, unitOfWork, httpContextAccessor)
    {
        _userManager = userManager;
        _authRules = authRules;
        _tokenService = tokenService;
        _configuration = configuration;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await _userManager.FindByEmailAsync(request.Email);
        bool checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);

        await _authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

        IList<string> roles = await _userManager.GetRolesAsync(user);

        JwtSecurityToken token = await _tokenService.CreateToken(user, roles);
        string refreshToken = _tokenService.GenerateRefreshToken();

        _ = int.TryParse(
            _configuration["JWT:RefreshTokenValidityInDays"],
            out int refreshTokenValidityInDays
        );

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);
        await _userManager.UpdateAsync(user);
        await _userManager.UpdateSecurityStampAsync(user);

        string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        await _userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", tokenString);
        return new LoginCommandResponse
        {
            Token = tokenString,
            RefreshToken = refreshToken,
            Expiration = token.ValidTo,
        };
    }
}
