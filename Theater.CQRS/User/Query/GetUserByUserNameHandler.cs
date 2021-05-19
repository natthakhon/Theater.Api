using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Theater.CQRS.Validator.User;
using Theater.Repository.User;
using U = Theater.Domain.User;

namespace Theater.CQRS.User.Query
{
    public class GetUserByUserNameHandler : BaseGetCommandHandler<GetUserByUserName, U.User>
    {
        public GetUserByUserNameHandler(IValidator<GetUserByUserName> validator, IUserRepository userRepository) : base(validator, userRepository) { }

        protected override Task<U.User> handle(GetUserByUserName request, CancellationToken cancellationToken)
        {
            return ((IUserRepository)this.repository).GetUserByUserNameAsync(request.UserName, request.Password);
        }
    }
}
