using BMSWPF.Model;
using BMSWPF.ViewModel.Commands;
using BMSWPF.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BMSWPF.ViewModel
{
    class SignupVM : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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


        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private string state;
        public string State
        {
            get { return state; }
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }

        private string country;
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }

        private string emailId;
        public string EmailId
        {
            get { return emailId; }
            set
            {
                emailId = value;
                OnPropertyChanged("EmailId");
            }
        }

        private string pan;
        public string PAN
        {
            get { return pan; }
            set
            {
                pan = value;
                OnPropertyChanged("PAN");
            }
        }

        private string contactNo;
        public string ContactNo
        {
            get { return contactNo; }
            set
            {
                contactNo = value;
                OnPropertyChanged("ContactNo");
            }
        }

        

        private string dob;
        public string DOB
        {
            get { return dob; }
            set
            {
                dob = value;
                OnPropertyChanged("DOB");
            }
        }


        private string accountType;
        public string AccountType
        {
            get { return accountType; }
            set
            {
                accountType = value;
                OnPropertyChanged("AccountType");
            }
        }

       

        public CreateAccountCommand CreateAccountCommand { get; set; }


        

        public event PropertyChangedEventHandler PropertyChanged;

        public SignupVM()
        {

            CreateAccountCommand = new CreateAccountCommand(this);
            
        }

        public async void CreateNewAccount()
        {
           

            string val = DOB.Contains("-") ? "-" : "/";
            string[] dates = DOB.Split(" ")[0].Split(val);
            string myDate = dates[1] + "/" + dates[0] + "/" + dates[2];

            UserDetail user = new UserDetail()
            {
                Name = Name,
                UserName = UserName,
                Password = Password,
                Address = Address,
                State = State,
                Country = Country,
                Email = EmailId,
                PAN = long.Parse(PAN),
                Contact = long.Parse(contactNo),
                DOB = DateTime.Parse(myDate),
                AccountType = AccountType.Split(":")[1].Trim()
            };

            string createAccountStatus = await SignupHelper.CreateAccount(user);
            if (createAccountStatus == "Added successfully")
            {
                Application.Current.Windows[Application.Current.Windows.Count-2].Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Something Went wrong");
                return;
            }
        }

    }
}
