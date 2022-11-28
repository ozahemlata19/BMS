using BMSAPI.Model.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSAPI.Repositories
{
    public interface IUserRepository
    {
        Task<int> ValidateUserCrudAsync(string userName, string password);
        Task<UserDetail> GetUserAsync(string userName);
        Task<bool> SaveUserDetailAsync(UserDetail userDetail);
        Task<bool> EndSessionAsync(string userName);
        Task<bool> ValidateUserSessionAsync(string userName);
    }
}
