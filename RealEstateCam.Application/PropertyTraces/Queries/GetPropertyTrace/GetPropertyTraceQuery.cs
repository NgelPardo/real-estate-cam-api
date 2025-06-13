using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.PropertyTraces.DTOs;

namespace RealEstateCam.Application.PropertyTraces.Queries.GetPropertyTrace
{
    public sealed record GetPropertyTraceQuery(Guid Id) : IQuery<PropertyTraceDto>
    {

    }
}
