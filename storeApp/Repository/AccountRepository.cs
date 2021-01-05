using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using storeApp.Models;

namespace storeApp.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AccountRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> CreateUserAsync(AccountModel userModel)
        {
            var user = new IdentityUser()
            {
                Email = userModel.Email,
                UserName = userModel.Email
            };

          var result =  await _userManager.CreateAsync(user, userModel.Password);
          return result;
        }
    }
}
