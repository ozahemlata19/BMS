using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BMSWPF.ViewModel
{
    class ApprovedStatusCommand : ICommand
    {
        public AdminInterfaceVM VM { get; set; }

        public ApprovedStatusCommand(AdminInterfaceVM vm)
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
            VM.ApproveCommand();
        }
    }
}
