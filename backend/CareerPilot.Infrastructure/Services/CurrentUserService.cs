using CareerPilot.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CareerPilot.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor) => _httpContextAccessor = httpContextAccessor;

        public Guid UserId
        {
            get
            {
                var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                return Guid.Parse(userId!);
            }
        }
    }
}
