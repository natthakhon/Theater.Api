using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Theater.CQRS
{
    public interface IRequestor<TResponse> : IRequest<TResponse>
        where TResponse :class
    {
        TResponse Item { set; get; }
    }
}
