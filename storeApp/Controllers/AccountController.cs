using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using storeApp.Models;
using storeApp.Repository;

namespace storeApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }


        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp(AccountModel userModel)
        {
            if (ModelState.IsValid)
            {
               var result = await _accountRepository.CreateUserAsync(userModel);
               if (!result.Succeeded)
               {
                   foreach (var error in result.Errors)
                   {
                       ModelState.AddModelError("",error.Description);
                   }

                   return View(userModel);
               }
               ModelState.Clear();
            }
            return View();
        }


        [Route("login")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> SignIn(SignInModel signInModel,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.SignInAsync(signInModel);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error signing in");
                }
            }
            return View(signInModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Route("Change-Password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Route("Change-Password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.ChangePassword(changePasswordModel);
                if (result.Succeeded)
                {
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                }
            }

            return View();
        }

    }
}
