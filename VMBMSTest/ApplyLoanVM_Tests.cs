using BMSWPF.ViewModel;
using BMSWPF.ViewModel.Commands;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMBMSTest
{
    [TestFixture]
    class ApplyLoanVM_Tests
    {

        private ApplyLoanVM applyLoanVM;
        private CreateLoanCommand applyLoanCommand;
        
        [SetUp]
        public void Setup()
        {
            applyLoanVM = new ApplyLoanVM();
            
            //setup variables
            GlobalVariables.USERNAME = TestData.LoanDetail.UserName;
            applyLoanVM.LoanAmount = "987654";
            applyLoanVM.LoanDate = DateTime.Now.ToString("MM/dd/yyyy");
            applyLoanVM.LoanDuration = "24";
            applyLoanVM.LoanType = "System.Windows.Controls.ComboBoxItem: Home";
        }

        [Test]
        public void CreateNewLoan_Test()
        {
            applyLoanCommand = new CreateLoanCommand(applyLoanVM);
            applyLoanCommand.CanExecute(null);
            applyLoanCommand.Execute(null);

            Assert.NotNull(applyLoanVM.ROI);
        }

        [Test]
        public void CreateNewLoan_LoanDuration_WithValue_Errors_Test()
        {
            applyLoanVM.LoanDuration = "0.0";
            applyLoanVM.CreateNewLoan();

            Assert.IsNotNull(applyLoanVM.LoanDuration);
        }

        [Test]
        public void CreateNewLoan_LoanAmount_Errors_Test()
        {
            applyLoanVM.LoanAmount = "test";
            applyLoanVM.CreateNewLoan();

            Assert.IsNotNull(applyLoanVM.LoanAmount);
        }

        [Test]
        public void CreateNewLoan_LoanDate_Errors_Test()
        {
            applyLoanVM.LoanDate = "02/02/2029";
            applyLoanVM.CreateNewLoan();

            Assert.IsNotNull(applyLoanVM.LoanDate);
        }

        [Test]
        public void CreateNewLoan_Dash_LoanDate_Test()
        {
            applyLoanVM.LoanDate = "02-02-2020";
            applyLoanVM.CreateNewLoan();

            Assert.IsNotNull(applyLoanVM.LoanDate);
        }

        [Test]
        public void CreateNewLoan_Shlash_LoanDate_Test()
        {
            applyLoanVM.LoanDate = "02/02/2020";
            applyLoanVM.CreateNewLoan();

            Assert.IsNotNull(applyLoanVM.LoanDate);
        }


    }
}
