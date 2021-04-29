using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using U = Theater.Domain.User;

namespace Theater.CQRS.User.Query
{
    public class GetUserByEmail : IRequest<U.User>
    {
        public string Email { get; set; }
    }
}
