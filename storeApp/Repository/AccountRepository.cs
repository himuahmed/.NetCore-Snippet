using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using storeApp.Models;
using storeApp.Service;

namespace storeApp.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;
        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
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


        public async Task<SignInResult> SignInAsync(SignInModel signInModel)
        {
          return await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);
        }

        public async Task SignOutAsync()
        {
             await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return await  _userManager.ChangePasswordAsync(user, changePasswordModel.CurrentPassword,
                changePasswordModel.NewPassword);
        }
    }
}
