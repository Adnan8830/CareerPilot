using CareerPilot.Application.Features.Profile.Commands.UpdateMyProfile;
using CareerPilot.Application.Features.Profile.Queries.GetMyProfile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerPilot.API.Controllers;

[ApiController]
[Route("api/profile")]
[Authorize]
public class ProfileController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetProfile()
    {
        var result = await _mediator.Send(new GetMyProfileQuery());

        return Ok(result);
    }


    [HttpPut]
    public async Task<IActionResult> UpdateProfile(
    UpdateMyProfileCommand command)
    {
       await _mediator.Send(command);
        return NoContent();
         
    }

}