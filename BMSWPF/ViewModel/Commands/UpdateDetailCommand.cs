using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BMSWPF.ViewModel.Commands
{
    public class UpdateDetailCommand :ICommand
    {
        public event EventHandler CanExecuteChanged;
        public UserInterfaceVM UserInterfaceVM { get; set; }

        public UpdateDetailCommand(UserInterfaceVM loan)
        {
            UserInterfaceVM = loan;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {
            UserInterfaceVM.ExecuteUpdate();
        }
    }
}
