using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMSAPI.Model.Domains;

namespace BMSAPI.Repositories
{
    public interface IApplyLoanRepository
    {
        Task<LoanDetail> GetLoanAsync(int loanId);
        Task<List<LoanDetail>> GetAllLoansAsync(string userName);
        Task<bool> SaveLoanDetailAsync(LoanDetail loanDetail);
        Task<bool> UpdateLoanStatusAsync(int loanId, string status);
        //Task<bool> UpdateLoanCommentAsync(int loanId, string comment);
        Task<List<LoanDetail>> GetAllAdminLoanAsync();

    }
}
