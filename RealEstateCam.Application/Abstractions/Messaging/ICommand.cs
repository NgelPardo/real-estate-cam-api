﻿using MediatR;
using RealEstateCam.Domain.Abstractions;

namespace RealEstateCam.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result>, IBaseCommand
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    { }

    public interface IBaseCommand
    { }
}
