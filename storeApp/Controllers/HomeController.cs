using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using storeApp.Service;

namespace storeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public HomeController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }
        public ViewResult Index()
        {
            var userId = _userService.GetUserId();
            var val = _configuration.GetValue<string>("RandomObject:value1");
            return View();
        }
    }
}
