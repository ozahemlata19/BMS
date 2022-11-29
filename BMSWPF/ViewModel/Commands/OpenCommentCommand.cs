using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BMSWPF.ViewModel
{
    class OpenCommentCommand : ICommand
    {
        public AdminInterfaceVM VM { get; set; }

        public OpenCommentCommand(AdminInterfaceVM vm)
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
            VM.OpenCommentWindow();
        }
    }
}
