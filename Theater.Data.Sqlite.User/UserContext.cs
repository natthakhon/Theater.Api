using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Theater.Data.Sqlite.User.Db;

namespace Theater.Data.Sqlite.User
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { set; get; }

        public UserContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(UserDatabase.DataSource());
        }
    }
}
