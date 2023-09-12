using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using System.IO;
using System.Data;

namespace AnimeSpace.Model
{
    class History
    {
        private SQLiteConnection connection;


        public History()
        {
            connection = DBConnection.GetConnection();
        }

        public DataSet ReadHistory()
        {
            connection.Open();
            SQLiteDataAdapter DA = new SQLiteDataAdapter("SELECT waktu, nama, path FROM history", connection);
            DataSet DS = new DataSet();
            DA.Fill(DS, "history");
            connection.Close();

            return DS;
        }

        public void CatatHistory(string path, string nama)
        {
            string waktu = DateTime.Now.ToString();

            SQLiteParameter[] sqlParams = new SQLiteParameter[] {
                new SQLiteParameter("@Waktu", waktu),
                new SQLiteParameter("@Path", path),
                new SQLiteParameter("@Nama", nama)
            };

            string addPathQuery = "INSERT INTO history (waktu, path, nama)" + "VALUES (@Waktu, @Path, @Nama)";
            connection.Open();
            SQLiteCommand command = connection.CreateCommand();
            command.Parameters.Add(sqlParams[0]);
            command.Parameters.Add(sqlParams[1]);
            command.Parameters.Add(sqlParams[2]);
            command.CommandText = addPathQuery;
            command.ExecuteNonQuery();
            connection.Close();

        }
    }
}
