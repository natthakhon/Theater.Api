using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Theater.Repository.User;
using U = Theater.Domain.User;

namespace Theater.CQRS.User.Query
{
    public class GetUserByUserNameHandler : IRequestHandler<GetUserByUserName, U.User>
    {
        private IUserRepository userRepository;
        public GetUserByUserNameHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<U.User> Handle(GetUserByUserName request, CancellationToken cancellationToken)
        {
            return await this.userRepository.GetUserByUserNameAsync(request.UserName);
        }
    }
}
