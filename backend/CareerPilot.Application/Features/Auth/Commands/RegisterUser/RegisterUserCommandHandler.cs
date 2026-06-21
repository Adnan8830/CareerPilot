using CareerPilot.Application.Interfaces;
using CareerPilot.Application.Interfaces.Repositories;
using CareerPilot.Domain.Entities;
using MediatR;
using CareerPilot.Application.Exceptions;

namespace CareerPilot.Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;


        public RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        => (_userRepository, _unitOfWork) = (userRepository, unitOfWork);

        public async Task<Guid> Handle(RegisterUserCommand request,CancellationToken cancellationToken)
        {

            var user = new User
            {
                FirstName = request.FirstName,
                LastName= request.LastName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                IsActive = true
            };

           var existingUser =  await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser is not null) throw new BadRequestException("User already exists");

            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return user.Id;

        }
    }
}
