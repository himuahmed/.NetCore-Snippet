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
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> CreateUserAsync(AccountModel userModel)
        {
            var user = new ApplicationUser()
            {
                Email = userModel.Email,
                UserName = userModel.Email,
                Name = userModel.Name,
                Address = userModel.Address
            };

          var result =  await _userManager.CreateAsync(user, userModel.Password);
          return result;
        }
    }
}
