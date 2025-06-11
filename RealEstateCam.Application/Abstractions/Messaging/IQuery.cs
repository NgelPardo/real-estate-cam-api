using MediatR;
using RealEstateCam.Domain.Abstractions;

namespace RealEstateCam.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
