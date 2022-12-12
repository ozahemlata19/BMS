using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BMSWPF.ViewModel.Commands
{
    public class SignupCommand : ICommand
    {
        public LoginVM VM { get; set; }

       
        public SignupCommand(LoginVM vm)
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
            VM.OpenSignupWindow();
        }
    }
}
