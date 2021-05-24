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
    public class CreateMovieCommandHandler : BaseCreateCommandHandler<M.Movie>
    {
        public CreateMovieCommandHandler(IValidator<M.Movie> validator, IMovieRepository repository) : base(validator, repository) { }

        protected override Task<M.Movie> handle(IRequestor<M.Movie> request, CancellationToken cancellationToken)
        {
            return this.repository.CreateAsync(request.Item);
        }
    }
}
