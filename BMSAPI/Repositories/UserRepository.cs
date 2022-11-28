using BMSAPI.Data;
using BMSAPI.JwtToken;
using BMSAPI.Model.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BMSDbContext bMSDbContext;

        ITokenManager _tokenManager = new TokenManager();

        public UserRepository(BMSDbContext bMSDbContext)
        {
            this.bMSDbContext = bMSDbContext;
        }

        public async Task<int> ValidateUserCrudAsync(string userName, string password)
        {
            UserDetail user = bMSDbContext.UserDetails?.Where(x =>
                                                                 x.UserName == userName &&
                                                                 x.Password == password).FirstOrDefault();


            if (user != null)
            {
                string userToken = user.Token;
                bool valid = _tokenManager.ValidateToken(userToken);

                if (valid)
                {
                    return user.Role;
                }
                else
                {
                    string token = _tokenManager.GenerateJsonWebToken(user.UserName);
                    user.Token = token;
                    await bMSDbContext.SaveChangesAsync();
                    return user.Role;
                }
            }
            else
                return 2;
        }

        public async Task<UserDetail> GetUserAsync(string userName)
        {
            return await bMSDbContext.UserDetails?.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<bool> SaveUserDetailAsync(UserDetail userDetail)
        {
            try
            {
                await bMSDbContext.UserDetails.AddAsync(userDetail);
                await bMSDbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> EndSessionAsync(string userName)
        {
            UserDetail userdetail = await GetUserAsync(userName);

            if(userdetail!=null)
            {
                userdetail.Token = "logout";
                await bMSDbContext.SaveChangesAsync();
                return true;
            }
            return false;
            
        }

        public async Task<bool> ValidateUserSessionAsync(string userName)
        {
            UserDetail userdetail = await GetUserAsync(userName);

            if (userdetail != null)
            {
                return _tokenManager.ValidateToken(userdetail.Token);
            }
            return false;

        }
    }
}
