using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Properties.DTOs;

namespace RealEstateCam.Application.Properties.Queries.GetAllProperties
{
    public sealed record GetAllPropertiesQuery() : IQuery<IReadOnlyList<PropertyWithExtrasDto>>
    {
    }
}
