using MediatR;
using Microsoft.AspNetCore.Mvc;
using CareerPilot.Application.Features.Auth.Commands.RegisterUser;
using CareerPilot.Application.Features.Auth.Queries.LoginUser;
using Microsoft.AspNetCore.Authorization;


namespace CareerPilot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator) => _mediator = mediator;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var userId = await _mediator.Send(command);

            return Ok(new 
            {
                Message= "User registered successfully.",
                UserId=userId
             });
        }

        [HttpPost("login")]
        
        public async Task<IActionResult> Login(LoginUserQuery query)
        {
            var token = await _mediator.Send(query);

            return Ok(new {Message="Login successful", Token = token });
        }


        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;

            return Ok(new
            {
                UserId = userId,
                Email = email
            });
        }

    }
}
