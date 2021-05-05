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
    public class GetUserByEmailHandler : BaseGetCommandHandler<GetUserByEmail, U.User>
    {
        public GetUserByEmailHandler(UserValidator validator, IUserRepository userRepository) : base(validator, userRepository) { }

        protected override Task<U.User> handle(GetUserByEmail request, CancellationToken cancellationToken)
        {
            return ((IUserRepository)this.repository).GetUserByEMailAsync(request.Email);
        }
    }
}
