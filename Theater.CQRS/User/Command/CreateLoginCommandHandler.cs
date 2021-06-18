using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Theater.Domain.User;
using Theater.Repository.User;
using dom = Theater.Domain.User;

namespace Theater.CQRS.User.Command
{
    public class CreateLoginCommandHandler : BaseCreateCommandHandler<dom.Login>
    {
        public CreateLoginCommandHandler(IValidator<dom.Login> validator, ILoginRepository repository)
            : base(validator, repository) { }

        protected override async Task<Login> handle(IRequestor<Login> request, CancellationToken cancellationToken)
        {
            return await this.repository.CreateAsync(request.Item);
        }
    }
}
