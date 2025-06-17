using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Owners.DTOs;

namespace RealEstateCam.Application.Owners.Queries.GetAllOwners
{
    public sealed record GetAllOwnersQuery() : IQuery<IReadOnlyList<OwnerDto>>
    {
    }
}
