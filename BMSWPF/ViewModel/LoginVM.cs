using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BMSWPF.Model.RequestData;
using BMSWPF.View;
using BMSWPF.ViewModel.Commands;
using BMSWPF.ViewModel.Helpers;

namespace BMSWPF.ViewModel
{
    public class LoginVM : INotifyPropertyChanged,IDataErrorInfo
    {
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        public string Error { get { return null; } }
        Regex regexusrname = new Regex("^[a-zA-Z0-9]*$");
        Regex regexpassword=new Regex(@"^.*(?=.{4,})(?=.*[a-zA-Z])(?=.*\d)(?=.*[!&$%&?@ ]).*$");
        public string this[string name]
        {
            get
            {
                string result = null;
                switch(name)
                {
                    case "UserName":
                        if (string.IsNullOrWhiteSpace(UserName))
                            result = "Username can not be empty";
                        else if(UserName.Length<4 || UserName.Length > 20)
                            result = "Username must be must be between 4 to 20 charactors.";
                        else if (!regexusrname.IsMatch(UserName))
                            result = "Username can not have special charactors.";
                        break;
                    case "Password":
                        if (string.IsNullOrWhiteSpace(Password))
                            result = "Password can not be empty";
                        else if (UserName.Length < 4 || UserName.Length > 20)
                            result = "Password must be must be between 4 to 20 charactors.";
                        else if (!regexpassword.IsMatch(Password))
                            result = "Password must contain atleast 1 capital and 1 small letter,special chars and 1 number";
                        break;

                }
                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = result;
                else if (result != null)
                    ErrorCollection.Add(name, result);
                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }


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
