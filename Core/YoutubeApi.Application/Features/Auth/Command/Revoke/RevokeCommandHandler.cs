using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Features.Auth.Rules;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Auth.Command.Revoke;

public class RevokeCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
{
    private readonly UserManager<User> _userManager;
    private readonly AuthRules _authRules;
    public RevokeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, AuthRules authRules, UserManager<User> userManager) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _authRules = authRules;
        _userManager = userManager;
    }

    public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await _userManager.FindByEmailAsync(request.Email);
        await _authRules.EmailAddressShouldBeValid(user);
        user.RefreshToken = null;
        await _userManager.UpdateAsync(user);
        return Unit.Value;
    }
}
