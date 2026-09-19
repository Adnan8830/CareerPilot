using CareerPilot.Application.Exceptions;
using CareerPilot.Application.Interfaces;
using CareerPilot.Application.Interfaces.Repositories;
using MediatR;

namespace CareerPilot.Application.Features.Resumes.Commands.DeleteResume;

public class DeleteResumeCommandHandler : IRequestHandler<DeleteResumeCommand>
{
    private readonly IResumeRepository _resumeRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly ICacheService _cacheService;
    private readonly IUnitOfWork _unitOfWork;


    public DeleteResumeCommandHandler(IResumeRepository resumeRepository, ICurrentUserService currentUserService, ICacheService cacheService, IUnitOfWork unitOfWork)
    {
        _resumeRepository = resumeRepository;
        _currentUserService = currentUserService;
        _cacheService = cacheService;
        _unitOfWork = unitOfWork;

    }


    public async Task Handle(DeleteResumeCommand request, CancellationToken cancellationToken)
    {
        var resume = await _resumeRepository.GetByIdAsync(request.Id);
        if (resume is null) throw new NotFoundException("Resume not found");

         _resumeRepository.Delete(resume);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var cacheKey = $"Resume_{_currentUserService.UserId}";
        await _cacheService.RemoveAsync(cacheKey);


    }
}
        
