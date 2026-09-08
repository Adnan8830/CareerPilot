using CareerPilot.Application.Features.Resumes.Commands.CreateResume;
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

    [HttpPost]
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
}