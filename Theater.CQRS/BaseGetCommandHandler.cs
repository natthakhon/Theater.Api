﻿using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Theater.Repository;

namespace Theater.CQRS
{
    public abstract class BaseGetCommandHandler<TRequest,TResponse> : IRequestHandler<TRequest, TResponse>
        where TResponse : class
        where TRequest : IRequest<TResponse>
    {
        private IValidator<TRequest> validator;
        protected IGenericRepository<TResponse> repository;
        protected BaseGetCommandHandler(IValidator<TRequest> validator
            , IGenericRepository<TResponse> repository)
        {
            this.validator = validator;
            this.repository = repository;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            ValidationResult result = this.validator.Validate(request); ;

            if (result.IsValid)
            {
                return await this.handle(request, cancellationToken);
            }
            throw new ArgumentException(String.Join(",", result.Errors));
        }

        protected abstract Task<TResponse> handle(TRequest request, CancellationToken cancellationToken);
        
    }
}
