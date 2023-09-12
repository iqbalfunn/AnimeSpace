using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace AnimeSpace.View
{
    /// <summary>
    /// Interaction logic for PageVideos.xaml
    /// </summary>
    public partial class PageVideos : Page
    {
        private Controller.ControllerFileAnime controllerFileAnime;
        //public int counterFolderOpen = 0;
        //public Stack<string> urutanFolderYangDibuka;
        private View.FilesMonitoringWindow filesMonitoringWindow;

        


        public PageVideos()
        {
            InitializeComponent();
            controllerFileAnime = new Controller.ControllerFileAnime(this);
            controllerFileAnime.ViewLibraryDB();
            //urutanFolderYangDibuka = new Stack<string>();
            
            
            
        }



        private void DGFileCatalog_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //textBlockParentFolder.Text = ((DataRowView)DGFileCatalog.SelectedItem).Row[1].ToString();
            string drv_id = ((DataRowView)DGFileCatalog.SelectedItem).Row[0].ToString(); //ngambil id dari row
            string drv_name = ((DataRowView)DGFileCatalog.SelectedItem).Row[1].ToString(); //ngambil name dari row
            controllerFileAnime.IsFolder(drv_id, drv_name);
        }

        private void Up_Dir_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //e.Handled = true;
            //MessageBox.Show("dipencett");
            
            if (controllerFileAnime.urutanBukaFoldersStack.Count > 0) //check kalo stack empty
            {
                //MessageBox.Show(controllerFileAnime.stackFolder.Peek());
                controllerFileAnime.BackToParentFolder();
            }
        }

        private void BtnAddScannedFolder_Click(object sender, RoutedEventArgs e)
        {
            //controllerFileAnime.ScanDir("E:");
            //controllerFileAnime.ViewLibraryDB();

            filesMonitoringWindow = new FilesMonitoringWindow();
            filesMonitoringWindow.ShowDialog();
            controllerFileAnime.ViewLibraryDB();

        }
    }


}
