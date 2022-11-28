using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMSWPF.Model.RequestData;
using BMSWPF.View;
using BMSWPF.ViewModel.Commands;
using BMSWPF.ViewModel.Helpers;

namespace BMSWPF.ViewModel
{
     class LoginVM : INotifyPropertyChanged
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

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private string alert;
        public string Alert
        {
            get { return alert; }
            set
            {
                alert = value;
                OnPropertyChanged("Alert");
            }
        }

        public SignupCommand SignupCommand { get; set; }

        public LoginSecurityCommand LoginSecurityCommand { get; set; }


        public LoginVM()
        {
            SignupCommand = new SignupCommand(this);
            LoginSecurityCommand = new LoginSecurityCommand(this);
        }

        public async void LoginQuery()
        {
            //validation
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
                return;
            try
            {
                string agent = await LoginSecurityHelper.LoginAgent(new LoginDetail { UserName = UserName, Password = Password });

                if (agent == "User")
                {
                   
                    //For User Login
                    GlobalVariables.USERNAME = UserName;
                    UserInterface dashboard = new UserInterface();
                    dashboard.ShowDialog();
                }
                else if (agent == "Admin")
                {
                    GlobalVariables.USERNAME = "admin";
                    AdminInterfaceWindow dashboard = new AdminInterfaceWindow();
                    dashboard.ShowDialog();
                }
                else
                {
                    Alert = "Something Went Wrong !!!";
                }
            }
            catch (Exception)
            {
                Alert = "Report to Administration.";
            }

        }
 

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OpenSignupWindow()
        {
            SignupWindow signup = new SignupWindow();
            signup.ShowDialog();
            
        }
    }
}
