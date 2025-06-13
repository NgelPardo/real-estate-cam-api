using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.PropertyTraces.DTOs;

namespace RealEstateCam.Application.PropertyTraces.Queries.GetPropertyTracesByIdProperty
{
    public sealed record GetPropertyTracesByIdPropertyQuery(Guid IdProperty) : IQuery<IReadOnlyList<PropertyTraceDto>>
    {

    }
}
