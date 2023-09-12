using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;

namespace AnimeSpace.Model
{
    class DBConnection
    {
        private static SQLiteConnection connection;
        

        public static SQLiteConnection GetConnection()
        {
            string path = @".\anime.db";
            connection = new SQLiteConnection();
            connection.ConnectionString = "Data Source = "+ path +"; Version=3; New=True; Compress=True;";

            return connection;
        }
    }
}
