using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstateCam.Application.Properties.Commands.CreateProperty;
using RealEstateCam.Application.Properties.DTOs;
using RealEstateCam.Application.Properties.Queries.GetAllProperties;
using RealEstateCam.Application.Properties.Queries.GetPropertiesByFilters;
using RealEstateCam.Application.Properties.Queries.GetProperty;
using RealEstateCam.Application.PropertyImages.Commands.CreatePropertyImage;
using RealEstateCam.Application.PropertyImages.Queries.GetPropertyImage;
using RealEstateCam.Application.PropertyImages.Queries.GetPropertyImageByIdProperty;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Infrastructure.Storage;

namespace RealEstateCam.Api.Controllers.Properties
{
    [ApiController]
    [Route("api/properties")]
    public class PropertiesController : ControllerBase
    {
        private readonly IFileStorage _fileStorage;
        private readonly ISender _sender;
        public PropertiesController(IFileStorage fileStorage, ISender sender)
        {
            _fileStorage = fileStorage;
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

        [HttpGet("property-image/{idProperty}")]
        public async Task<IActionResult> GetPropertyImage(
            Guid idProperty,
            CancellationToken cancellationToken
            )
        {
            GetPropertyImageByIdPropertyQuery query = new GetPropertyImageByIdPropertyQuery(idProperty);
            var result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess 
                ? Ok(result.Value) 
                : BadRequest(new { error = result.Error });
        }

        [HttpPost("property-image")]
        public async Task<IActionResult> CreatePropertyImage(
            [FromForm] Guid idProperty,
            [FromForm] IFormFile file,
            [FromForm] bool enabled,
            CancellationToken cancellationToken
            )
        {
            var imageUrl = await _fileStorage.SaveFileAsync(file, "uploads");

            CreatePropertyImageCommand command = new CreatePropertyImageCommand(idProperty, imageUrl, enabled);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(GetPropertyImage), new { idProperty }, idProperty);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetByFilters(
            [FromQuery] string? name,
            [FromQuery] string? address,
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice,
            CancellationToken cancellationToken
            )
        {
            var query = new GetPropertiesByFiltersQuery(name, address, minPrice, maxPrice);

            var results = await _sender.Send(query, cancellationToken);

            if (results.IsSuccess)
                return Ok(results.Value);

            return BadRequest(results.Error);
        }
    }
}
