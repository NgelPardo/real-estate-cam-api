using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Properties.DTOs;

namespace RealEstateCam.Application.Properties.Queries.GetPropertiesByFilters
{
    public sealed record GetPropertiesByFiltersQuery(string? Name, string? Address, decimal? MinPrice, decimal? MaxPrice) : IQuery<IReadOnlyList<PropertyWithExtrasDto>>
    {
    }
}
