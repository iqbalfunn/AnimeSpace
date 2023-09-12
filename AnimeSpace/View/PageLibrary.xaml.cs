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
using AnimeSpace.Controller;
using System.Data;

namespace AnimeSpace.View
{
    /// <summary>
    /// Interaction logic for PageLibrary.xaml
    /// </summary>
    public partial class PageLibrary : Page
    {
        //private ControllerFileAnime controllerFileAnime;
        private View.PageVideos pageVideos;
        private View.PageHistory pageHistory;
        private ControllerHistory controllerHistory;

        public PageLibrary()
        {
            InitializeComponent();
            pageVideos = new PageVideos();
            
            //controllerFileAnime = new Controller.ControllerFileAnime(this);
            //controllerFileAnime.DatabaseCheck();
            FrameTabLibrary.Content = pageVideos;
            controllerHistory = new ControllerHistory(this);
        }



        private void LVIVideos_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameTabLibrary.Content = pageVideos;

        }

        private void LVIHistory_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pageHistory = new PageHistory();
            FrameTabLibrary.Content = pageHistory;
            //controllerHistory.ViewHistoryDB();
        }
    }
}
