using System;
using System.Collections.Generic;
using System.Text;
using Theater.Domain.User;
using dom = Theater.Domain.User;

namespace Theater.CQRS.User.Command
{
    public class CreateLoginCommand : IRequestor<dom.Login>
    {
        public Login Item { get; set; }
    }
}
