using CareerPilot.Application.Features.Resumes.Commands.CreateResume;
using CareerPilot.Application.Features.Resumes.Commands.DeleteResume;
using CareerPilot.Application.Features.Resumes.Commands.UpdateResume;
using CareerPilot.Application.Features.Resumes.Queries.GetMyResume;
using CareerPilot.Application.Features.Resumes.Queries.GetResumeById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ResumeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResumeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    [Authorize]
    public async Task<IActionResult> Create([FromBody]CreateResumeCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }


    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetMyResume()
    {
        var result = await _mediator.Send(new GetMyResumeQuery());

        return Ok(result);
    }


    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(
        new GetResumeByIdQuery(id));
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Update(
    Guid id,
    [FromBody] UpdateResumeCommand command)
    {
        if (id != command.Id)
            return BadRequest("Resume ID mismatch.");

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize]

    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteResumeCommand(id));
        return NoContent();
    }
}