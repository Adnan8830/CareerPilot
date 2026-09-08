using CareerPilot.Application.DTOs;
using CareerPilot.Application.Interfaces;
using CareerPilot.Application.Interfaces.Repositories;
using CareerPilot.Domain.Entities;
using MediatR;

namespace CareerPilot.Application.Features.Resumes.Queries.GetMyResume
{
    public class GetMyResumeQueryHandler
        : IRequestHandler<GetMyResumeQuery, IEnumerable<ResumeDto>>
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ICacheService _cacheService;

        public GetMyResumeQueryHandler(
            IResumeRepository resumeRepository,
            ICurrentUserService currentUserService, ICacheService cacheService)
        {
            _resumeRepository = resumeRepository;
            _currentUserService = currentUserService;
            _cacheService = cacheService;

        }

        public async Task<IEnumerable<ResumeDto>> Handle(
            GetMyResumeQuery request,
            CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            string key = $"Resume_{userId}";

            var resumes = await _cacheService.GetAsync<IEnumerable<ResumeDto>>(key);

            if (resumes is not null) return resumes;
            

            var resumeEntities = await _resumeRepository
                .GetByUserIdAsync(userId);

            resumes = resumeEntities.Select(resume => new ResumeDto
            {
                Id= resume.Id,
                Name = resume.Name,
                Version = resume.Version,
                FilePath = resume.FilePath
            }).ToList();


            await _cacheService.SetAsync(key, resumes, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(2));

            return resumes;
        }
    }
}