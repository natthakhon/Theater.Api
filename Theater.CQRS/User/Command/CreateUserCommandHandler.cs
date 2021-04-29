using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Theater.Domain.Validator.User;
using Theater.Repository.User;
using U = Theater.Domain.User;

namespace Theater.CQRS.User.Command
{
    public class CreateUserCommandHandler : BaseCreateCommandHandler<U.User>
    {
        public CreateUserCommandHandler(UserValidator validator, IUserRepository repository) 
            : base(validator,repository) { }

        protected override Task<U.User> handle(IRequestor<U.User> request, CancellationToken cancellationToken)
        {
            return this.repository.CreateAsync(request.Item);
        }
    }
}
