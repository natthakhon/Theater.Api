using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theater.Data.Sqlite.User
{
    [Table("Login")]
    public class Login
    {
        [Key]
        public string LoginId { set; get; }
        public User User { set; get; }
        public DateTime LogDate { set; get; }
        public bool IsOff { set; get; }
    }
}
