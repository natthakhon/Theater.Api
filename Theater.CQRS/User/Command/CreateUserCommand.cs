using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using U = Theater.Domain.User;

namespace Theater.CQRS.User.Command
{
    public class CreateUserCommand : IRequestor<U.User>
    {
        public U.User Item { get; set ; }
    }
}
