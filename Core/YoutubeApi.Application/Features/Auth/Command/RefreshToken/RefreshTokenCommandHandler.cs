using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SendGrid.Helpers.Errors.Model;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Features.Auth.Rules;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.Interfaces.Tokens;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Auth.Command.RefreshToken;

public class RefreshTokenCommandHandler
    : BaseHandler,
        IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly AuthRules _authRules;

    public RefreshTokenCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        UserManager<User> userManager, AuthRules authRules, ITokenService tokenService)
        : base(mapper, unitOfWork, httpContextAccessor)
    {
        _userManager = userManager;
        _authRules = authRules;
        _tokenService = tokenService;
    }

    public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
     {
        var principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
        string email = principal.FindFirstValue(ClaimTypes.Email);
        var user = await _userManager.FindByEmailAsync(email);
        IList<string> roles = await _userManager.GetRolesAsync(user);

        await _authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryTime);

        JwtSecurityToken newAccessToken = await _tokenService.CreateToken(user, roles);
        string newRefreshToken = _tokenService.GenerateRefreshToken();
        
        user.RefreshToken = newRefreshToken;
        await _userManager.UpdateAsync(user);
        await _userManager.UpdateSecurityStampAsync(user);

        return new()
        {
            RefreshToken = newRefreshToken,
            AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
        };
     }
}
