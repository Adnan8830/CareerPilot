using CareerPilot.Application.Interfaces;
using CareerPilot.Application.Interfaces.Repositories;
using CareerPilot.Domain.Entities;
using MediatR;

namespace CareerPilot.Application.Features.Resumes.Commands.CreateResume
{
    public class CreateResumeCommandHandler : IRequestHandler<CreateResumeCommand, Guid>
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateResumeCommandHandler(
        IResumeRepository resumeRepository,
        ICurrentUserService currentUserService,
        IUnitOfWork unitOfWork)
        {
            _resumeRepository = resumeRepository;
            _currentUserService = currentUserService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
        CreateResumeCommand request,
        CancellationToken cancellationToken)
        {
            var resume = new Resume
            {
                Name = request.Name,
                FilePath = request.FilePath,
                Version = 1,
                UserId = _currentUserService.UserId
            };


            await _resumeRepository.AddAsync(resume);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return resume.UserId;

        }

    }
}
