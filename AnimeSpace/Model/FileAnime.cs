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
    class FileAnime  //Class untuk mengurusi File. Untuk scanning, simpen ke DB, update, delete
    {
        private SQLiteConnection connection;
        
        

        //private List<Path>;  // array buat path


        public FileAnime()
        {
            connection = DBConnection.GetConnection();
        }

        //delete item di filemonitoringwindow
        public void DeleteSelectedFolderList(string path)
        {
            SQLiteParameter[] sqlParams = new SQLiteParameter[] {
                new SQLiteParameter("@Path", path),
            };

            string addPathQuery = "DELETE FROM foldersToScan WHERE pathFolder = @Path";
            connection.Open();
            SQLiteCommand command = connection.CreateCommand();
            command.Parameters.Add(sqlParams[0]);
            command.CommandText = addPathQuery;
            command.ExecuteNonQuery();
            connection.Close();
        }


        //save hasil openfolderdialog
        public void SaveFolderList(string path)
        {
            SQLiteParameter[] sqlParams = new SQLiteParameter[] {
                new SQLiteParameter("@Path", path),
            };

            string addPathQuery = "INSERT INTO foldersToScan (pathFolder)" + "VALUES ( @Path)";
            connection.Open();
            SQLiteCommand command = connection.CreateCommand();
            command.Parameters.Add(sqlParams[0]);
            command.CommandText = addPathQuery;
            command.ExecuteNonQuery();
            connection.Close();

        }


        public DataSet GetFolderToScan() //ambil data files untuk parent folder
        {
            connection.Open();
            SQLiteDataAdapter DA = new SQLiteDataAdapter("SELECT pathFolder FROM foldersToScan", connection);
            DataSet DS = new DataSet();
            DA.Fill(DS, "foldersToScan");
            connection.Close();

            return DS;
        }



        public DataSet BackToParentFolder(string id) //ambil data files untuk parent folder
        {
            connection.Open();
            SQLiteDataAdapter DA = new SQLiteDataAdapter("SELECT id, name, path, is_folder FROM files WHERE parent_id = (SELECT parent_id FROM files WHERE id = "+ id + ")", connection);
            DataSet DS = new DataSet();
            DA.Fill(DS, "files");
            connection.Close();

            return DS;
        }


        public DataSet ReadLibrary()
        {
            //connection.Open();
            SQLiteDataAdapter DA = new SQLiteDataAdapter("SELECT id, name, path, is_folder FROM files WHERE parent_id = (SELECT id FROM files WHERE parent_id IS NULL) ", connection);
            DataSet DS = new DataSet();
            DA.Fill(DS, "files");
            connection.Close();

            return DS;
        }

        public DataSet OpenFolder(string id)
        {
            connection.Open();
            SQLiteDataAdapter DA = new SQLiteDataAdapter("SELECT id, name, path, is_folder FROM files WHERE parent_id = "+ id +" ", connection);
            DataSet DS = new DataSet();
            DA.Fill(DS, "folder");
            connection.Close();

            return DS;
        }


        //Scan target dir and then save it to DB

        //Nyimpen top directory layer

        private void InsertTopLayerDirectory(string parentPath, string[] filesPath, string[] foldersPath) //buat nyimpen ke DB
        {
            //MessageBox.Show(parentPath);

            string parentName = Path.GetFileName(parentPath);

            SQLiteParameter[] sqlParams = new SQLiteParameter[] {
                new SQLiteParameter("@ParentPath", parentPath),
                new SQLiteParameter("@ParentName", parentName)
            };

            string query_add_parent = "INSERT INTO files (name, path, is_folder)" + "VALUES ( @ParentName , @ParentPath , 1)"; 
            string query_id_parent = "SELECT id FROM files WHERE name = @parentName";
            string id_parent = "";

            connection.Open();
            SQLiteCommand command = connection.CreateCommand();
            command.Parameters.Add(sqlParams[0]);
            command.Parameters.Add(sqlParams[1]);
            command.CommandText = query_add_parent;

            command.ExecuteNonQuery();


            command.CommandText = query_id_parent;
            SQLiteDataReader dataReader;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                id_parent = dataReader.GetInt32(0).ToString();
            }

            dataReader.Close();

            foreach (string filePath in filesPath)
            {
                // get filename from path!
                string fileName = Path.GetFileName(filePath);

                SQLiteParameter[] sqlParams2 = new SQLiteParameter[] {
                new SQLiteParameter("@FilePath", filePath),
                new SQLiteParameter("@FileName", fileName)
                };
                
                string query_add_file = "INSERT INTO files (name, path, parent_id, is_folder) VALUES (@FileName, @FilePath ,'" + id_parent + "', 0)";
                command.Parameters.Add(sqlParams2[0]);
                command.Parameters.Add(sqlParams2[1]);
                command.CommandText = query_add_file;
                command.ExecuteNonQuery();
            }

            
            foreach (string folderPath in foldersPath)
            {


                // get filename from path!
                string folderName = Path.GetFileName(folderPath);


                SQLiteParameter[] sqlParams3 = new SQLiteParameter[] {
                new SQLiteParameter("@FolderPath", folderPath),
                new SQLiteParameter("@FolderName", folderName)
                };
                string query_add_file = "INSERT INTO files (name, path, parent_id, is_folder) VALUES (@FolderName, @FolderPath,'" + id_parent + "', 1)";
                command.Parameters.Add(sqlParams3[0]);
                command.Parameters.Add(sqlParams3[1]);
                command.CommandText = query_add_file;
                command.ExecuteNonQuery();
            }
            

            connection.Close();

        }


        //buat insert dir layer selanjutnya
        private void InsertNextLayerDirectory(string parentPath, string[] filesPath, string[] foldersPath) //buat nyimpen ke DB
        {
            //MessageBox.Show(parentPath);
            //string parentName = Path.GetFileName(parentPath);
            //string query_add_parent = "INSERT INTO files (name, path, is_folder) VALUES ( '" + parentName + "' ,'" + parentPath + "','1')"; //parent_id nya kita biarkan null ==> SALAH, PARENT GA IKUT DIMASUKIN
            string query_id_parent = "SELECT id FROM files WHERE path = '" + parentPath + "'";
            string id_parent = "";

            connection.Open();
            SQLiteCommand command = connection.CreateCommand();
            //command.CommandText = query_add_parent;
            //command.ExecuteNonQuery();


            command.CommandText = query_id_parent;
            SQLiteDataReader dataReader;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                id_parent = dataReader.GetInt32(0).ToString();
            }

            dataReader.Close();

            /*
            foreach (string filePath in filesPath)
            {
                // get filename from path!
                string filename = Path.GetFileName(filePath);
                string query_add_file = "INSERT INTO files (name, path, parent_id, is_folder) VALUES ('" + filename + "', '" + filePath + "' ,'" + id_parent + "', '0')";
                command.CommandText = query_add_file;
                command.ExecuteNonQuery();
            }
            */

            foreach (string filePath in filesPath)
            {
                // get filename from path!
                string fileName = Path.GetFileName(filePath);

                SQLiteParameter[] sqlParams2 = new SQLiteParameter[] {
                new SQLiteParameter("@FilePath", filePath),
                new SQLiteParameter("@FileName", fileName)
                };

                string query_add_file = "INSERT INTO files (name, path, parent_id, is_folder) VALUES (@FileName, @FilePath ,'" + id_parent + "', 0)";
                command.Parameters.Add(sqlParams2[0]);
                command.Parameters.Add(sqlParams2[1]);
                command.CommandText = query_add_file;
                command.ExecuteNonQuery();
            }

            /*
            foreach (string folderPath in foldersPath)
            {
                // get filename from path!
                string folderName = Path.GetFileName(folderPath);
                string query_add_file = "INSERT INTO files (name, path, parent_id, is_folder) VALUES ('" + folderName + "', '" + folderPath + "' ,'" + id_parent + "', '1')";
                command.CommandText = query_add_file;
                command.ExecuteNonQuery();
            }
            */

            foreach (string folderPath in foldersPath)
            {
                // get filename from path!
                string folderName = Path.GetFileName(folderPath);
      
                SQLiteParameter[] sqlParams3 = new SQLiteParameter[] {
                new SQLiteParameter("@FolderPath", folderPath),
                new SQLiteParameter("@FolderName", folderName)
                };
                string query_add_file = "INSERT INTO files (name, path, parent_id, is_folder) VALUES (@FolderName, @FolderPath,'" + id_parent + "', 1)";
                command.Parameters.Add(sqlParams3[0]);
                command.Parameters.Add(sqlParams3[1]);
                command.CommandText = query_add_file;
                command.ExecuteNonQuery();
            }

            connection.Close();

        }




        

        public void ProcessTopLayerDirectory(string targetDirectory)
        {
           
            // Process the list of files found in the directory.
            //string[] fileEntries = Directory.GetFiles(targetDirectory);
            var ext = new List<string> { "mkv", "mp4", "avi" };
            string[] fileEntries = Directory
                .EnumerateFiles(targetDirectory, "*.*", SearchOption.TopDirectoryOnly)
                .Where(s => ext.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()) && !s.Contains("$RECYCLE.BIN")).ToArray();

          

            // Recurse into subdirectories of this directory.
            //string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            string[] subdirectoryEntries = Directory
                .EnumerateDirectories(targetDirectory, "*", SearchOption.TopDirectoryOnly)
                .Where(s => !s.Contains("$RECYCLE.BIN") && !s.Contains("System Volume Information")).ToArray();


            InsertTopLayerDirectory(targetDirectory, fileEntries, subdirectoryEntries);

            foreach (string subdirectory in subdirectoryEntries)
            {
                //try
                //{

                    ProcessNextLayerDirectory(subdirectory);
                    
                //}
                //catch { } // Don't know what the problem is, don't care...
            }

        }

        private void ProcessNextLayerDirectory(string targetDirectory)
        {
            var ext = new List<string> { "mkv", "mp4" };
            string[] fileEntries = Directory
                .EnumerateFiles(targetDirectory, "*.*", SearchOption.TopDirectoryOnly)
                .Where(s => ext.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()) && !s.Contains("$RECYCLE.BIN")).ToArray();

            string[] subdirectoryEntries = Directory
                .EnumerateDirectories(targetDirectory, "*", SearchOption.TopDirectoryOnly)
                .Where(s => !s.Contains("$RECYCLE.BIN") && !s.Contains("System Volume Information")).ToArray();


            InsertNextLayerDirectory(targetDirectory, fileEntries, subdirectoryEntries);

            foreach (string subdirectory in subdirectoryEntries)
            {
                //try
                //{

                    ProcessNextLayerDirectory(subdirectory);

                //}
                //catch { } // Don't know what the problem is, don't care...
            }

        }



        // Insert logic for processing found files here.
        private string Get(string path)
        {
            string filename = Path.GetFileName(path);
            return filename;
        }
        
    }
}
