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
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Data;

namespace AnimeSpace.View
{
    /// <summary>
    /// Interaction logic for FilesMonitoringWindow.xaml
    /// </summary>
    public partial class FilesMonitoringWindow : Window
    {
        private Controller.ControllerFileAnime controllerFileAnime;
        private FolderBrowserDialog folderBrowserDialog;
        

        public FilesMonitoringWindow()
        {
            InitializeComponent();
            controllerFileAnime = new Controller.ControllerFileAnime(this);
            controllerFileAnime.ViewFolderScanList();
            folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            
        }

        private void BtnAddFolder_Click(object sender, RoutedEventArgs e)
        {
            //folderBrowserDialog.ShowDialog();
            
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //System.Windows.MessageBox.Show(folderBrowserDialog.SelectedPath);
                controllerFileAnime.SaveFolderList(folderBrowserDialog.SelectedPath);
                controllerFileAnime.ViewFolderScanList();
            }
        }

        private void BtnDeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            //DataRowView drv = (DataRowView)LvScanDir.SelectedItems[0];
            //System.Windows.MessageBox.Show(drv[0].ToString());
            controllerFileAnime.DeleteSelectedFolderList();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            controllerFileAnime.UpdateFileMonitoring();
        }
    }
}
