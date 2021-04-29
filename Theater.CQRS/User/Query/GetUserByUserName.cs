using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using U = Theater.Domain.User;

namespace Theater.CQRS.User.Query
{
    public class GetUserByUserName : IRequest<U.User>
    {
        public string UserName { get; set; }
    }
}
