using CareerPilot.Application.Features.JobApplications.Commands.CreateJobApplication;
using CareerPilot.Application.Features.JobApplications.Commands.DeleteJobApplication;
using CareerPilot.Application.Features.JobApplications.Commands.UpdateJobApplication;
using CareerPilot.Application.Features.JobApplications.Queries.GetJobApplicationById;
using CareerPilot.Application.Features.JobApplications.Queries.GetJobApplicationsByStatus;
using CareerPilot.Application.Features.JobApplications.Queries.GetMyJobApplications;
using CareerPilot.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CareerPilot.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobApplicationController : ControllerBase
    {
        public readonly IMediator _mediator;

        public JobApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateJobApplicationCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMyApplication()
        {
            var result = await _mediator.Send(new GetMyJobApplicationsQuery());

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [Authorize]

        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(
                new GetJobApplicationByIdQuery(id));

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        [Authorize]

        public async Task<IActionResult> UpdateById(UpdateJobApplicationCommand command, Guid id)
        {
            if(command.Id!=id)
                return BadRequest("Route ID and request ID do not match.");

            await _mediator.Send(command);

            return NoContent();

        }


        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(
                new DeleteJobApplicationCommand(id));

            return NoContent();
        }

        [HttpGet("status")]
        [Authorize]
        public async Task<IActionResult> GetByStatus(
        [FromQuery] ApplicationStatus status)
        {
            var result = await _mediator.Send(
                new GetJobApplicationsByStatusQuery(status));

            return Ok(result);
        }

    }
}
