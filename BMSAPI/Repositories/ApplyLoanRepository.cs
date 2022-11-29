using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMSAPI.Data;
using BMSAPI.Model.Domains;
using Microsoft.EntityFrameworkCore;

namespace BMSAPI.Repositories
{
    
    public class ApplyLoanRepository :IApplyLoanRepository
    {
        private readonly BMSDbContext bMSDbContext;

        public ApplyLoanRepository(BMSDbContext bMSDbContext)
        {
            this.bMSDbContext = bMSDbContext;
        }

        public async Task<bool> UpdateLoanStatusAsync(int loanId, string status)
        {
            try
            {
                LoanDetail loan = await GetLoanAsync(loanId);
                if (loan != null)
                {
                    loan.Status = status;

                    bMSDbContext.LoanDetails.Update(loan);
                    await bMSDbContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<List<LoanDetail>> GetAllLoansAsync(string userName)
        {
            return await bMSDbContext.LoanDetails?.Where(x =>x.UserName == userName).ToListAsync();
        }



        public async Task<LoanDetail> GetLoanAsync(int loanId)
        {
            return await bMSDbContext.LoanDetails?.FirstOrDefaultAsync(x => x.LoanId == loanId);
        }

        public async Task<bool> SaveLoanDetailAsync(LoanDetail loanDetail)
        {
            try
            {
                await bMSDbContext.LoanDetails.AddAsync(loanDetail);
                await bMSDbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<List<LoanDetail>> GetAllAdminLoanAsync()
        {
            return await bMSDbContext.LoanDetails?.ToListAsync();
        }

    }
}
