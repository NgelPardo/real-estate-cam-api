using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstateCam.Application.Users.Commands.LoginUser;
using RealEstateCam.Application.Users.Commands.RegisterUser;
using RealEstateCam.Application.Users.DTOs;
using RealEstateCam.Application.Users.Queries.GetUser;
using RealEstateCam.Domain.Abstractions;

namespace RealEstateCam.Api.Controllers.Users
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly ISender _sender;
        public UsersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginUserRequest loginUserRequest,
            CancellationToken cancellationToken
        )
        {
            LoginCommand loginCommand = new LoginCommand(loginUserRequest.email, loginUserRequest.password);

            Result result = await _sender.Send(loginCommand, cancellationToken);

            if (result.IsFailure)
            {
                return Unauthorized(result.Error);
            }

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(
            [FromBody] RegisterUserRequest request,
            CancellationToken cancellationToken
        )
        {
            RegisterUserCommand command = new RegisterUserCommand(
                request.nombre,
                request.apellido,
                request.email,
                request.password
            );

            var resultado = await _sender.Send(command, cancellationToken);

            if (resultado.IsFailure)
            {
                return BadRequest(resultado.Error);
            }

            return CreatedAtAction(nameof(GetUser), new { id = resultado.Value }, resultado.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(
            Guid id,
            CancellationToken cancellationToken
        )
        {
            GetUserQuery query = new GetUserQuery(id);
            Result resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado) : NotFound();
        }
    }
}
