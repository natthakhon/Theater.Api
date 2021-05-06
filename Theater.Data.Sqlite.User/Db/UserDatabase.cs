using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Theater.Data.Sqlite.User.Db
{
    public static class UserDatabase
    {
        private static string Location
        {
            get
            {
                return Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf("Theater.Api")+11);
            }
        }

        private static string FileName
        {
            get
            {
                return "User.db";
            }
        }

        public static string DataSource()
        {
            return string.Format(@"Data Source={0}\\{1}", Location, FileName);
        }
        
    }
}
