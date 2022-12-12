﻿using BMSWPF.Model;
using BMSWPF.View;
using BMSWPF.ViewModel.Commands;
using BMSWPF.ViewModel.Helpers;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSWPF.ViewModel
{
    public class AdminInterfaceVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private BindableCollection<LoanDetail> loanDetails;

        public BindableCollection<LoanDetail> LoanDetails
        {
            get { return loanDetails; }
            set
            {
                loanDetails = value;
                OnPropertyChanged("LoanDetails");
            }
        }

        public OpenCommentCommand OpenCommentCommand { get; set; }
        public ApprovedStatusCommand ApprovedStatusCommand { get; set; }
        public RejectCommand RejectCommands { get; set; }

        public AdminInterfaceVM()
        {
            OpenCommentCommand = new OpenCommentCommand(this);
            ApprovedStatusCommand = new ApprovedStatusCommand(this);
            RejectCommands = new RejectCommand(this);
            if (!string.IsNullOrEmpty(GlobalVariables.COMMENT))
            {
                CommentCommand();
            }

            DisplayAllAttributes();
        }

        public async void CommentCommand()
        {
            await UpdateDetailHelper.UpdateLoanComment(GlobalVariables.LOANID, GlobalVariables.COMMENT);
        }

        public void OpenCommentWindow()
        {
            new CommentWindow().ShowDialog();
        }

        private async void DisplayAllAttributes()
        {
            var response = await PreviousAppliedLoanHelper.GetAdminLoanDetail();
            LoanDetails = new BindableCollection<LoanDetail>(response);
        }

        public async void ApproveCommand()
        {
            string checkValue = LoanDetails[GlobalVariables.LOANID - 1].Status;
            if (checkValue != "Pending")
            {
                System.Windows.MessageBox.Show("Can't Change the Status");
                return;
            }

            await UpdateDetailHelper.UpdateLoanStatus(GlobalVariables.LOANID, "APPROVED");
            DisplayAllAttributes();
            GlobalVariables.COMMENT = "";
            new CommentWindow().ShowDialog();
        }

        public async void RejectCommand()
        {
            string checkValue = LoanDetails[GlobalVariables.LOANID - 1].Status;
            if (checkValue != "Pending")
            {
                System.Windows.MessageBox.Show("Can't Change the Status");
                return;
            }
            await UpdateDetailHelper.UpdateLoanStatus(GlobalVariables.LOANID, "REJECTED");
            DisplayAllAttributes();
            GlobalVariables.COMMENT = "";
            new CommentWindow().ShowDialog();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

