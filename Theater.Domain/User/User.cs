using System;
using System.Collections.Generic;
using System.Text;

namespace Theater.Domain.User
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Format("{0} {1}", this.Name, this.LastName); } }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
