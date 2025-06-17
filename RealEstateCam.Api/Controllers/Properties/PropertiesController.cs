using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstateCam.Application.Properties.Commands.CreateProperty;
using RealEstateCam.Application.Properties.DTOs;
using RealEstateCam.Application.Properties.Queries.GetAllProperties;
using RealEstateCam.Application.Properties.Queries.GetProperty;

namespace RealEstateCam.Api.Controllers.Properties
{
    [ApiController]
    [Route("api/properties")]
    public class PropertiesController : ControllerBase
    {
        private readonly ISender _sender;
        public PropertiesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetProperties(
            Guid id,
            CancellationToken cancellationToken)
        {
            GetAllPropertiesQuery query = new GetAllPropertiesQuery();
            var results = await _sender.Send(query, cancellationToken);

            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProperty(
            Guid id,
            CancellationToken cancellationToken
            )
        {
            GetPropertyQuery query = new GetPropertyQuery(id);
            var result = await _sender.Send(query,cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty(
            PropertyRequest request,
            CancellationToken cancellationToken
            )
        {
            CreatePropertyCommand commmand = new CreatePropertyCommand(
                request.name,
                request.address,
                request.price,
                request.codeInternal,
                request.year,
                request.idOwner
            );

            var result = await _sender.Send(commmand, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(GetProperty), new { id = result.Value }, result.Value);
        }
    }
}
