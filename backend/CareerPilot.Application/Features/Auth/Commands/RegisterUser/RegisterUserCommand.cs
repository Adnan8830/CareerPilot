using MediatR;

namespace CareerPilot.Application.Features.Auth.Commands.RegisterUser;
    public record RegisterUserCommand(string FirstName,string LastName,string Email,string Password) : IRequest<Guid> ;

