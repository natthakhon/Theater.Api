using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using dom = Theater.Domain.User;

namespace Theater.CQRS.User.Query
{
    public class GetLoginById : IRequest<dom.Login>
    {
        public string Id { get; set; }
    }
}
