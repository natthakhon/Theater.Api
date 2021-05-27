using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Theater.Repository.Movie;
using M = Theater.Domain.Movie;

namespace Theater.CQRS.Movie.Command
{
    public class CreateTheaterCommandHandler : BaseCreateCommandHandler<M.Theater>
    {
        public CreateTheaterCommandHandler(IValidator<M.Theater> validator, ITheaterRepository repository):base(validator, repository) { }

        protected override Task<M.Theater> handle(IRequestor<M.Theater> request, CancellationToken cancellationToken)
        {
            return this.repository.CreateAsync(request.Item);
        }
    }
}
