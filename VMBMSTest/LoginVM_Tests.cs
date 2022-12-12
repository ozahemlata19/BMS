using BMSWPF.ViewModel;
using BMSWPF.ViewModel.Commands;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VMBMSTest
{
    [TestFixture]
    class LoginVM_Tests
    {
        private LoginVM loginSecurityVM;
        private LoginSecurityCommand loginSecurityCommand;
        private SignupCommand signupCommand;

        [SetUp]
        public void Setup()
        {
            loginSecurityVM = new LoginVM();
            loginSecurityCommand = new LoginSecurityCommand(loginSecurityVM);
            signupCommand = new SignupCommand(loginSecurityVM);
        }

        [Test]
        public void SignupWindow_Test()
        {
            // create a thread  
            Thread newWindowThread = new Thread(new ThreadStart(() =>
            {
                // create and show the window
                // your code
                signupCommand.CanExecute(null);
                signupCommand.Execute(null);

                // start the Dispatcher processing  
                System.Windows.Threading.Dispatcher.Run();
            }));

            // set the apartment state  
            newWindowThread.SetApartmentState(ApartmentState.STA);

            // make the thread a background thread  
            newWindowThread.IsBackground = true;

            // start the thread  
            newWindowThread.Start();


            Assert.IsNull(loginSecurityVM.UserName);
        }

        [Test]
        [TestCase("suhani")]
        [TestCase("123456")]
        public void LoginSecurityVM_UserNameValidation_Pass_Test(string username)
        {
            loginSecurityVM.UserName = username;
            Assert.AreEqual(username, loginSecurityVM.UserName);
        }

        [Test]
        [TestCase("suhani%")]
        [TestCase("!@#$%^*")]
        public void LoginSecurityVM_UserNameValidation_Fail_Test(string username)
        {
            loginSecurityVM.UserName = username;
            Assert.AreEqual(username, loginSecurityVM.UserName);
        }

        [Test]
        [TestCase("Suhani@05")]
        [TestCase("Suhani&007")]
        public void LoginSecurityVM_PasswordValidation_Pass_Test(string password)
        {
            loginSecurityVM.Password = password;
            Assert.AreEqual(password, loginSecurityVM.Password);
        }

        [Test]
        [TestCase("Suhani05")]
        [TestCase("suhani#05")]
        [TestCase("12")]
        [TestCase("&%^&!")]
        public void LoginSecurityVM_PasswordValidation_Fail_Test(string password)
        {
            loginSecurityVM.Password = password;
            Assert.AreEqual(password, loginSecurityVM.Password);
        }

        [Test]
        public void LoginSecurityQuery_Test()
        {
            loginSecurityVM.UserName = "test";
            loginSecurityVM.Password = "Test@121";

            loginSecurityCommand.CanExecute(null);
            loginSecurityCommand.Execute(null);

            Assert.IsNull(loginSecurityVM.Alert);

        }

        [Test]
        public void LoginSecurityQuery_UserName_Fail_Test()
        {
            loginSecurityVM.Password = "Test@121";

            loginSecurityCommand.CanExecute(null);
            loginSecurityCommand.Execute(null);

            Assert.IsNull(loginSecurityVM.UserName);

        }

        [Test]
        public void LoginSecurityQuery_Password_Fail_Test()
        {
            loginSecurityVM.UserName = "test";

            loginSecurityCommand.CanExecute(null);
            loginSecurityCommand.Execute(null);

            Assert.IsNull(loginSecurityVM.Password);

        }

        [Test]
        public void LoginSecurityVM_Alert_Test()
        {
            loginSecurityVM.Alert = "Something Went Wrong";
            Assert.NotNull(loginSecurityVM.Alert);
        }

    }
}
