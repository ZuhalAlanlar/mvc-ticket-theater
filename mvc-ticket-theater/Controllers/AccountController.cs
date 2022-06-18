using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc_ticket_theater.Data;
using mvc_ticket_theater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        private readonly AppDbContext context;

        public AccountController(UserManager<AppUser>userManager,SignInManager<AppUser> signInManager,AppDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
