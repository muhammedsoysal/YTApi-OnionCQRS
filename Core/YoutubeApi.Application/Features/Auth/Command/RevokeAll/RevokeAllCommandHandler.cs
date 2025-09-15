using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Auth.Command.RevokeAll;

public class RevokeAllCommandHandler : BaseHandler, IRequestHandler<RevokeAllCommandRequest, Unit>
{
    private readonly UserManager<User> _userManager;
    public RevokeAllCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(RevokeAllCommandRequest request, CancellationToken cancellationToken)
    {
        IList<User> users = await _userManager.Users.ToListAsync(cancellationToken);

        foreach (var user in users)
        {
            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);
        }
        return  Unit.Value;
    }
}
