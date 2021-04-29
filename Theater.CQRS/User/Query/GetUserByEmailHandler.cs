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
    public class GetUserByEmailHandler : BaseGetCommandHandler<U.User> 
    {
        public GetUserByEmailHandler(UserValidator validator
            , IUserRepository userRepository) :base(validator,userRepository)
        {
            
        }

        protected override Task<U.User> handle(IRequestor<U.User> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
