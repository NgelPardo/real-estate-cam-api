using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.PropertyImages.DTOs;

namespace RealEstateCam.Application.PropertyImages.Queries.GetPropertyImage
{
    public sealed record GetPropertyImageQuery(Guid IdPropertyImage) : IQuery<PropertyImageDto>
    {
    }
}
