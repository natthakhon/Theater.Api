using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Theater.Domain.User;
using Theater.Repository.User;
using dom = Theater.Domain.User;

namespace Theater.CQRS.User.Query
{
    public class GetLoginByIdHandler : BaseGetCommandHandler<GetLoginById, dom.Login>
    {
        public GetLoginByIdHandler(IValidator<GetLoginById> validator, ILoginRepository userRepository) 
            : base(validator, userRepository) { }

        protected override Task<Login> handle(GetLoginById request, CancellationToken cancellationToken)
        {
            return ((ILoginRepository)this.repository).GetLoginById(request.Id);
        }
    }
}
