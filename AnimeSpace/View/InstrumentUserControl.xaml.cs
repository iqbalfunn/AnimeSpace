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
using System.ComponentModel;

namespace AnimeSpace.View
{
    /// <summary>
    /// Interaction logic for InstrumentUserControl.xaml
    /// </summary>
    public partial class InstrumentUserControl : UserControl, INotifyPropertyChanged
    {
        // We should put this in a separate user control, but for now for testing
        // let's put the grid configuration in here
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }

        public InstrumentUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HELLO!", "Greetings", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CreateGrid_Click(object sender, RoutedEventArgs e)
        {
            
            if (int.TryParse(rowSizeText.Text, out int rowResult))
            {
                RowCount = rowResult;
                GridHelpers.SetStarRows(GridGua, "0,1,2");
                OnPropertyChanged("RowCount");
                
            }

            if (int.TryParse(columnSizeText.Text, out int columnResult))
            {
                ColumnCount = columnResult;
                GridHelpers.SetStarColumns(GridGua, "0,1,2");
                OnPropertyChanged("ColumnCount");
            }
            

            /*
            RowCount = 6;
            GridHelpers.SetStarRows(GridGua, "5");
            ColumnCount = 4;
            GridHelpers.SetStarColumns(GridGua, "1,3");
            OnPropertyChanged("RowCount");
            OnPropertyChanged("ColumnCount");
            */

        }
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
