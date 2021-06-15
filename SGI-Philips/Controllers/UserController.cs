using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SGI_Philips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGI_Philips.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<Usuario> _userManager;

        public UserController(UserManager<Usuario> userManager)
        {            
            _userManager = userManager;            
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
    }
}
