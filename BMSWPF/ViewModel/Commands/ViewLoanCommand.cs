using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BMSWPF.ViewModel.Commands
{
    public class ViewLoanCommand :ICommand
    {
        public event EventHandler CanExecuteChanged;
        public AdminInterfaceVM AdminInterfaceVM { get; set; }

        public ViewLoanCommand(AdminInterfaceVM loan)
        {
            AdminInterfaceVM = loan;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {
            //AdminInterfaceVM.ExecuteLoan();
        }
    }
}
