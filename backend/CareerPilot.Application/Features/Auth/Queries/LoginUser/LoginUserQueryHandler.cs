using CareerPilot.Application.Exceptions;
using CareerPilot.Application.Interfaces;
using CareerPilot.Application.Interfaces.Repositories;
using MediatR;

namespace CareerPilot.Application.Features.Auth.Queries.LoginUser;

    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public LoginUserQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator) 
        => (_userRepository, _jwtTokenGenerator) = (userRepository,jwtTokenGenerator);

        public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
             if (user is null) throw new UnauthorizedException("Invalid Credentials");

        var isValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
        if(isValid is false)
            throw new UnauthorizedException("Invalid Credentials");

        return _jwtTokenGenerator.GenerateToken(user.Id,user.Email);

    }

    
}

