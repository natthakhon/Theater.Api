using System;
using System.Collections.Generic;
using System.Text;

namespace Theater.Domain.User
{
    public class Login
    {
        public string LoginId { set; get; }
        public User User { set; get; }
        public DateTime LogDate { set; get; }
        public bool IsOff { set; get; }
    }
}
