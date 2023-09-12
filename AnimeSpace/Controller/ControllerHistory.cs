using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Data;

namespace AnimeSpace.Controller
{
    class ControllerHistory
    {
        private Model.History modelHistory;
        private View.PageHistory pageHistory;
        private View.PageLibrary pageLibrary;

        public ControllerHistory(View.PageHistory pageHistory)
        {
            this.pageHistory = pageHistory;
            modelHistory = new Model.History();
        }

        public ControllerHistory(View.PageLibrary pageLibrary)
        {
            this.pageLibrary = pageLibrary;
            modelHistory = new Model.History();
            pageHistory = new View.PageHistory();
        }

        public void ViewHistoryDB()
        {
            DataSet DS_History = new DataSet();
            DS_History = modelHistory.ReadHistory();
            //pageHistory.LvHistory.DataContext = DS_History.Tables[0].DefaultView;

            //Binding binding = new Binding();

            //pageHistory.LvHistory.ItemsSource = DateTime.Parse(DS_History.Tables[0].Rows[0][0].ToString());
            pageHistory.LvHistory.ItemsSource = DS_History.Tables[0].DefaultView;

            //pageHistory.LvHistory.ItemsSource = DS_History.Tables[0].DefaultView;
            //pageHistory.LvHistory.

        }
    }
}
