using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.PropertyImages.DTOs;

namespace RealEstateCam.Application.PropertyImages.Queries.GetPropertyImageByIdProperty
{
    public sealed record GetPropertyImageByIdPropertyQuery(Guid IdProperty) : IQuery<PropertyImageDto>
    {

    }
    
}
