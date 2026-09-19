using CareerPilot.Application.Exceptions;
using CareerPilot.Application.Interfaces;
using CareerPilot.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPilot.Application.Features.JobApplications.Commands.DeleteJobApplication
{
    public class DeleteJobApplicationCommandHandler
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUnitOfWork _unitOfWork;


        public DeleteJobApplicationCommandHandler(
            IJobApplicationRepository jobApplicationRepository,
            ICurrentUserService currentUserService,
            IUnitOfWork unitOfWork)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _currentUserService = currentUserService;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(
                DeleteJobApplicationCommand request,
                CancellationToken cancellationToken)
        {
            var application = await _jobApplicationRepository
                .GetByIdAsync(request.Id);

            if (application is null)
                throw new NotFoundException("Job application not found.");

            if (application.UserId != _currentUserService.UserId)
                throw new UnauthorizedException(
                    "You are not authorized to delete this job application.");

            _jobApplicationRepository.Delete(application);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
