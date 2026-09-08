using MediatR;

namespace CareerPilot.Application.Features.Auth.Queries.LoginUser;
    public class LoginUserQuery :  IRequest
    {
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
        
    }

