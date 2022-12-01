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
        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }
        public ApplyLoanCommand ApplyLoanCommand { get; set; }
        public UpdateDetailCommand UpdateDetailCommand { get; set; }

        public UserInterfaceVM()
        {
            ApplyLoanCommand = new ApplyLoanCommand(this);
            UpdateDetailCommand = new UpdateDetailCommand(this);
            UserName = GlobalVariables.USERNAME;
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

        public void ExecuteUpdate()
        {
            UpdateDetailWindow updt = new UpdateDetailWindow();
            updt.ShowDialog();
        }
    }
}
