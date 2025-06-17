using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstateCam.Application.Owners.Commands.CreateOwner;
using RealEstateCam.Application.Owners.DTOs;
using RealEstateCam.Application.Owners.Queries.GetAllOwners;
using RealEstateCam.Application.Owners.Queries.GetOwner;

namespace RealEstateCam.Api.Controllers.Owners
{
    [ApiController]
    [Route("api/owners")]
    public class OwnersController : ControllerBase
    {
        private readonly ISender _sender;
        public OwnersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetOwners(
            Guid id,
            CancellationToken cancellationToken
            )
        {
            GetAllOwnersQuery query = new GetAllOwnersQuery();
            var results = await _sender.Send(query, cancellationToken);

            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwner(
            Guid id,
            CancellationToken cancellationToken
            )
        {
            GetOwnerQuery query = new GetOwnerQuery(id);
            var result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner(
            OwnerRequest request,
            CancellationToken cancellationToken
            )
        {
            CreateOwnerCommand command = new CreateOwnerCommand(
                request.name,
                request.address,
                request.photo,
                request.birthday
            );

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(GetOwner), new { id = result.Value }, result.Value);
        }
    }
}
