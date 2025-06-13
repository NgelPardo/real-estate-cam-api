using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Owners.DTOs;

namespace RealEstateCam.Application.Owners.Queries.GetOwner
{
    public sealed record GetOwnerQuery(Guid IdOwner) : IQuery<OwnerDto>;
}
