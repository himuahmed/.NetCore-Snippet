using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using storeApp.Models;

namespace storeApp.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(AccountModel userModel);
        Task<SignInResult> SignInAsync(SignInModel signInModel);
        Task SignOutAsync();
        Task<IdentityResult> ChangePassword(ChangePasswordModel changePasswordModel);
    }
}