using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstateCam.Application.Owners.Commands.CreateOwner;
using RealEstateCam.Application.Owners.DTOs;
using RealEstateCam.Application.Owners.Queries.GetAllOwners;
using RealEstateCam.Application.Owners.Queries.GetOwner;
using RealEstateCam.Infrastructure.Storage;

namespace RealEstateCam.Api.Controllers.Owners
{
    [ApiController]
    [Route("api/owners")]
    public class OwnersController : ControllerBase
    {
        private readonly IFileStorage _fileStorage;
        private readonly ISender _sender;
        public OwnersController(IFileStorage fileStorage, ISender sender)
        {
            _fileStorage = fileStorage;
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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateOwner(
            [FromForm] string name,
            [FromForm] string address,
            [FromForm] IFormFile photo,
            [FromForm] DateTime birthday,
            CancellationToken cancellationToken
            )
        {
            var photoUrl = await _fileStorage.SaveFileAsync(photo, "uploads");

            CreateOwnerCommand command = new CreateOwnerCommand(
                name,
                address,
                photoUrl,
                birthday
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
