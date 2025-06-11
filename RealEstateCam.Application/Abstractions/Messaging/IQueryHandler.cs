using MediatR;
using RealEstateCam.Domain.Abstractions;

namespace RealEstateCam.Application.Abstractions.Messaging
{
    public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
    {

    }
}
