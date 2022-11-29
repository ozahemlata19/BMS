using BMSWPF.View;
using BMSWPF.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BMSWPF.ViewModel
{
    class UserInterfaceVM : INotifyPropertyChanged
    {
        public ApplyLoanCommand ApplyLoanCommand { get; set; }
        //public UpdateUserCommand UpdateUserCommand { get; set; }

        public UserInterfaceVM()
        {
            ApplyLoanCommand = new ApplyLoanCommand(this);
            //UpdateUserCommand = new UpdateUserCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ExecuteLoan()
        {
            ApplyLoanWindow loan = new ApplyLoanWindow();
            loan.ShowDialog();
        }
    }
}
