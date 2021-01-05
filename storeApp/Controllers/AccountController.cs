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
               }
               ModelState.Clear();
            }
            return View();
        }


    }
}
