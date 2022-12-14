using BMSWPF.Model;
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

namespace BMSWPF.View
{
    /// <summary>
    /// Interaction logic for AdminInterfaceWindow.xaml
    /// </summary>
    public partial class AdminInterfaceWindow : Window
    {
        public AdminInterfaceWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            LoanDetail row = dg.SelectedItem as LoanDetail;
            if (row != null)
                ViewModel.GlobalVariables.LOANID = row.LoanId;
        }
    }
}
