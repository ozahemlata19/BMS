using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BMSWPF.ViewModel.Commands
{
    public class CreateLoanCommand : ICommand
    {
        public ApplyLoanVM ApplyLoanVM { get; set; }
        public event EventHandler CanExecuteChanged;
        public CreateLoanCommand(ApplyLoanVM apploan)
        {
            ApplyLoanVM = apploan;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ApplyLoanVM.CreateNewLoan();
        }
    }
}
