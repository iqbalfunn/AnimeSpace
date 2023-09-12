using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Controls;
using System.Windows;

namespace AnimeSpace.Controller
{
    class ControllerFileAnime
    {
        private Model.FileAnime fileAnime;
        private View.PageVideos pageVideos;
        DataSet DS_Anime;
        //public Stack<string> stackFolder;
        private View.FilesMonitoringWindow filesMonitoringWindow;
        private DataSet DS_folderList;
        private Model.History history;
        private Controller.ControllerHistory controllerHistory;
        public Stack<UrutanBukaFolder> urutanBukaFoldersStack;



        public ControllerFileAnime(View.FilesMonitoringWindow filesMonitoringWindow)
        {
            this.filesMonitoringWindow = filesMonitoringWindow;
            fileAnime = new Model.FileAnime();
            DS_folderList = new DataSet();
            pageVideos = new View.PageVideos();
        }


        public ControllerFileAnime(View.PageVideos pageVideos)
        {
            this.pageVideos = pageVideos;
            fileAnime = new Model.FileAnime();
            DS_Anime = new DataSet();
            //stackFolder = new Stack<string>();
            history = new Model.History();
            urutanBukaFoldersStack = new Stack<UrutanBukaFolder>();
        }

        //fungsi khusus buat prototype. cuma scan item paling atas
        public void UpdateFileMonitoring()
        {
            string path = DS_folderList.Tables[0].Rows[0][0].ToString();
            ScanDir(path);
            
        }


        public void DeleteSelectedFolderList()
        {
            DataRowView drv = (DataRowView)filesMonitoringWindow.LvScanDir.SelectedItems[0];
            fileAnime.DeleteSelectedFolderList(drv[0].ToString());

            ViewFolderScanList();
        }

        public void SaveFolderList(string path)
        {
            fileAnime.SaveFolderList(path);
        }

        public void ViewFolderScanList()
        {
            //DataSet DS_folderList = new DataSet();
            DS_folderList = fileAnime.GetFolderToScan();
            //masukin ke listview

            filesMonitoringWindow.LvScanDir.DataContext = DS_folderList.Tables[0].DefaultView;
            //filesMonitoringWindow.LvScanDir.
        }


        public void ScanDir(string path)
        {
            fileAnime.ProcessTopLayerDirectory(path);
        }


        public void OpenFolder(string id, string name)  //buat buka folder di view
        {
            //push id dan name ke stack
            var folder = new UrutanBukaFolder(id, name);

            //stackFolder.Push(id);
            urutanBukaFoldersStack.Push(folder);
            
            pageVideos.textBlockParentFolder.Text = name;

            DS_Anime = fileAnime.OpenFolder(id);
            pageVideos.DGFileCatalog.DataContext = DS_Anime.Tables[0].DefaultView;
        }

        public void BackToParentFolder() //buat up directory dari folder di view
        {
            //MessageBox.Show(stackFolder.Peek());
            DS_Anime = fileAnime.BackToParentFolder(urutanBukaFoldersStack.Pop().id.ToString());
            pageVideos.DGFileCatalog.DataContext = DS_Anime.Tables[0].DefaultView;

            if(urutanBukaFoldersStack.Count > 0)
            {
                pageVideos.textBlockParentFolder.Text = urutanBukaFoldersStack.Peek().nama.ToString(); //harusnya peek element sebelum top atau n-1
            }
            else
            {
                pageVideos.textBlockParentFolder.Text = "Root";
            }
            
        }



        public void ViewLibraryDB()
        {
            DS_Anime = fileAnime.ReadLibrary();
            pageVideos.DGFileCatalog.DataContext = DS_Anime.Tables[0].DefaultView;
        }



        public void IsFolder(string id, string name)
        {
            DataRow[] rows = DS_Anime.Tables[0].Select("id = '" + id + "'");
            string is_folder = rows[0]["is_folder"].ToString();
            //string id = rows[0]["id"].ToString();
            if ( is_folder == "1")
            {
                //MessageBox.Show("isi: " + isfolder);
                //pageVideos.counterFolderOpen++;
                //if (pageVideos.counterFolderOpen > 1)
                //{

                //}
                
                OpenFolder(id, name);
            }
            else
            {
                string namaFile = ((DataRowView)pageVideos.DGFileCatalog.SelectedItem).Row[1].ToString();
                string pathFile = rows[0]["path"].ToString();
                //MessageBox.Show("0");
                PlayVideo(pathFile);
                history.CatatHistory(pathFile, namaFile);
                //controllerHistory.ViewHistoryDB();

            }
        }

        /*
        public string FindRowInDataSet(string namaFile)
        {
            DataRow[] rows = DS_Anime.Tables[0].Select("name = '" + namaFile + "'");
            return rows[0]["path"].ToString();
            
        }
        */

        public void PlayVideo(string path)
        {
            System.Diagnostics.Process.Start(@"" + path);
        }




    }

    public class UrutanBukaFolder
    {
        public string id;
        public string nama;

        // Create a class constructor with a parameter
        public UrutanBukaFolder(string idParam, string namaParam)
        {
            id = idParam;
            nama = namaParam;
        }
    }
}
