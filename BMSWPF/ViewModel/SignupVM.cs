using BMSWPF.Model;
using BMSWPF.ViewModel.Commands;
using BMSWPF.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace BMSWPF.ViewModel
{
    public class SignupVM : INotifyPropertyChanged, IDataErrorInfo
    {
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        public string Error { get { return null; } }
        Regex regexusrname = new Regex("^[a-zA-Z0-9]*$");
        Regex regexpan = new Regex("^[a-zA-Z0-9]*$");
        Regex regexname = new Regex("^[a-zA-Z]*$");
        Regex regexpassword = new Regex(@"^.*(?=.{4,})(?=.*[a-zA-Z])(?=.*\d)(?=.*[!&$%&?@ ]).*$");
        Regex regexemail = new Regex(@"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$");
        public string this[string nameval]
        {
            get
            {
                string result = null;
                switch (nameval)
                {
                    case "UserName":
                        if (string.IsNullOrWhiteSpace(UserName))
                            result = "Username can not be empty";
                        else if (UserName.Length < 4 || UserName.Length > 20)
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
                    case "Name":
                        if (string.IsNullOrWhiteSpace(Name))
                            result = "Name can not be empty";
                        else if (Name.Length > 50)
                            result = "Name can not have more than 50 charactors.";
                        else if (!regexname.IsMatch(Name))
                            result = "Name can only have alphabets.";
                        break;
                    case "PAN":
                        if (string.IsNullOrWhiteSpace(PAN))
                            result = "PAN can not be empty";
                        else if (PAN.Length != 10)
                            result = "PAN should have 10 charactors.";
                        else if (!regexpan.IsMatch(PAN))
                            result = "PAN can not have special charactors.";
                        break;
                    case "EmailId":
                        if (string.IsNullOrWhiteSpace(EmailId))
                            result = "Email Id can not be empty";
                        else if (!regexemail.IsMatch(EmailId))
                            result = "Email Id should be in standard format.";
                        break;
                    case "ContactNo":
                        if (string.IsNullOrWhiteSpace(ContactNo))
                            result = "Contact Number can not be empty";
                        else if (Convert.ToDecimal(ContactNo) > 9999999999 )
                            result = "Contact Number must be of 10 numbers";
                        break;
                    case "DOB":
                        if (Convert.ToDateTime(DOB) > DateTime.Now.AddYears(-18))
                            result = "User should be of above 18 years of age.";
                        //else if (Convert.ToDateTime(DOB) > DateTime.Now)
                        //    result = "Future date is not allowed.";
                        break;
                    case "Address":
                        if (string.IsNullOrWhiteSpace(Address))
                            result = "Address can not be empty";
                        else if (Address.Length > 200)
                            result = "Address can not have more than 200 charactors.";
                        break;
                    case "State":
                        if (string.IsNullOrWhiteSpace(State))
                            result = "State can not be empty";
                        else if (State.Length > 50)
                            result = "State can not have more than 50 charactors.";
                        break;
                    case "Country":
                        if (string.IsNullOrWhiteSpace(Country))
                            result = "Country can not be empty";
                        else if (Country.Length > 100)
                            result = "Country can not have more than 100 charactors.";
                        break;
                }
                if (ErrorCollection.ContainsKey(nameval))
                    ErrorCollection[nameval] = result;
                else if (result != null)
                    ErrorCollection.Add(nameval, result);
                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }






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
