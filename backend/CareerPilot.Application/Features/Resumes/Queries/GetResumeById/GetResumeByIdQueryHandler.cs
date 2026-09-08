using CareerPilot.Application.DTOs;
using CareerPilot.Application.Exceptions;
using CareerPilot.Application.Interfaces;
using CareerPilot.Application.Interfaces.Repositories;
using MediatR;

namespace CareerPilot.Application.Features.Resumes.Queries.GetResumeById
{
    public class GetResumeByIdQueryHandler : IRequestHandler<GetResumeByIdQuery, ResumeDto>
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly ICurrentUserService _currentUserService;
        public GetResumeByIdQueryHandler(
            IResumeRepository resumeRepository,
            ICurrentUserService currentUserService)
        {
            _resumeRepository = resumeRepository;
            _currentUserService = currentUserService;
        }

        public async Task<ResumeDto> Handle(
            GetResumeByIdQuery request,
            CancellationToken cancellationToken)
        {
            var resume = await _resumeRepository.GetByIdAsync(request.Id);

            if (resume is null)
                throw new NotFoundException("Resume not found.");

            if (resume.UserId != _currentUserService.UserId)
                throw new UnauthorizedException(
                    "You are not authorized to access this resume.");

            return new ResumeDto
            {
                Id = resume.Id,
                Name = resume.Name,
                Version = resume.Version,
                FilePath = resume.FilePath
            };
        }

    }
}
