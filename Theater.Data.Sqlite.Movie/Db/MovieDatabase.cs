using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Theater.Data.Sqlite.Movie.Db
{
    public static class MovieDatabase
    {
        private static string Location
        {
            get
            {
                return Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf("Theater.Api") + 11);
            }
        }

        private static string FileName
        {
            get
            {
                return "Movie.db";
            }
        }

        public static string DataSource()
        {
            return string.Format(@"Data Source={0}\\{1}", Location, FileName);
        }
    }
}
