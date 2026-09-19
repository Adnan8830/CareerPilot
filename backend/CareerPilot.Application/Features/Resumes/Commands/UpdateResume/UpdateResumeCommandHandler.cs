using MediatR;
using CareerPilot.Application.Exceptions;
using CareerPilot.Application.Interfaces;
using CareerPilot.Application.Interfaces.Repositories;

namespace CareerPilot.Application.Features.Resumes.Commands.UpdateResume
{
    public class UpdateResumeCommandHandler :  IRequestHandler<UpdateResumeCommand>
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;

        public UpdateResumeCommandHandler(IResumeRepository resumeRepository,
            ICurrentUserService currentUserService,
            IUnitOfWork unitOfWork,
            ICacheService cacheService)
        {
            _resumeRepository = resumeRepository;
            _currentUserService = currentUserService;
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }

        public async Task Handle(UpdateResumeCommand request, CancellationToken cancellationToken)
        {
            var resume = await _resumeRepository.GetByIdAsync(request.Id);

            if (resume == null)
                throw new NotFoundException("Resume not found.");

            if (resume.UserId != _currentUserService.UserId)
                throw new UnauthorizedException(
                    "You are not authorized to update this resume.");

            resume.Name = request.Name;
            resume.FilePath = request.FilePath;

            _resumeRepository.Update(resume);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cacheKey = $"Resume_{resume.Id}_{_currentUserService.UserId}";

            await _cacheService.RemoveAsync(cacheKey);
        }

      
    }
}
