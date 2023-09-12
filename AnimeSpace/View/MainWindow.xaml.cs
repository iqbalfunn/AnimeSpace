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

namespace AnimeSpace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private View.PageLibrary pageLibrary;
        private View.PageExplore pageExplore;

        public MainWindow()
        {
            InitializeComponent();
            pageLibrary = new View.PageLibrary();
            pageExplore = new View.PageExplore();
            Main.Content = pageLibrary;

        }



        /*
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Style rowStyle = new Style(typeof(DataGridRow));
            rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent,
                                     new MouseButtonEventHandler(Row_DoubleClick)));
            DGFileCatalog.RowStyle = rowStyle;


            DataGridRow row = sender as DataGridRow;
            // Some operations with this row

            controllerFileAnime.OpenFolder(row.Item.ToString());
        }
        */

        /*
        private void DGFileCatalog_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //DataGridRow dgr = (DataGridRow)DGFileCatalog.SelectedItem;
            //string namaFile = dgr[].to
            //MessageBox.Show(namaFile);

            string drv = ((DataRowView)DGFileCatalog.SelectedItem).Row[0].ToString();
            controllerFileAnime.IsFolder(drv);

            //MessageBox.Show(path);
            //controllerFileAnime.PlayVideo(path);

            //System.Diagnostics.Process.Start(@"e:\joker.mp4");
        }
        */

        private void BtnLibrary_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = pageLibrary;
            

            //Main.Content = new View.PageLibrary();
        }

        private void BtnExplore_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = pageExplore;
        }
    }
}
