﻿using BMSWPF.Model;
using BMSWPF.ViewModel.Commands;
using BMSWPF.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSWPF.ViewModel
{
    class ApplyLoanVM : INotifyPropertyChanged
    {
        private string loanType;

        public string LoanType
        {
            get { return loanType; }
            set
            {
                loanType = value;
                OnPropertyChanged("LoanType");
            }
        }

        private string loanAmount;

        public string LoanAmount
        {
            get { return loanAmount; }
            set { loanAmount = value; OnPropertyChanged("LoanAmount"); }
        }

        private string loanDate;

        public string LoanDate
        {
            get { return loanDate; }
            set { loanDate = value; OnPropertyChanged("LoanDate"); }
        }

        private string roi;

        public string ROI
        {
            get { return roi; }
            set { roi = value; OnPropertyChanged("ROI"); }
        }

        private string loanDuration;

        public event PropertyChangedEventHandler PropertyChanged;

        public string LoanDuration
        {
            get { return loanDuration; }
            set
            {
                loanDuration = value;
                float duration = float.Parse(LoanDuration);
                ROI = (duration / 12).ToString();
                OnPropertyChanged("LoanDuration");
            }
        }

        public ApplyLoanVM()
        {
            CreateLoanCommand = new CreateLoanCommand(this);
        }

        public CreateLoanCommand CreateLoanCommand { get; set; }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void CreateNewLoan()
        {
           

            float duration = float.Parse(LoanDuration);
            ROI = (duration / 12).ToString();

            string val = LoanDate.Contains("-") ? "-" : "/";
            string[] dates = LoanDate.Split(" ")[0].Split(val);
            string myDate = dates[1] + "/" + dates[0] + "/" + dates[2];

            LoanDetail loan = new LoanDetail()
            {
                UserName = GlobalVariables.USERNAME,
                LoanType = LoanType.Split(":")[1].Trim(),
                LoanDate = DateTime.Parse(myDate),
                LoanAmount = double.Parse(LoanAmount),
                LoanDuration = int.Parse(LoanDuration),
                RateOfInterest = float.Parse(ROI),
                Status = "Pending"
            };

            string status = await ApplyLoanHelper.CreateLoan(loan);

            System.Windows.MessageBox.Show(status);
           
        }

    }
}
