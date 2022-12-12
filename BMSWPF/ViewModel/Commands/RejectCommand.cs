using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BMSWPF.ViewModel
{
    public class RejectCommand : ICommand
    {
        public AdminInterfaceVM VM { get; set; }

        public RejectCommand(AdminInterfaceVM vm)
        {
            VM = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.RejectCommand();
        }
    }
}
