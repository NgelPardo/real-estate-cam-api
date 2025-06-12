using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Properties.DTOs;

namespace RealEstateCam.Application.Properties.Queries.GetProperty
{
    public sealed record GetPropertyQuery(Guid IdProperty) : IQuery<PropertyDto>
    {

    }
}
