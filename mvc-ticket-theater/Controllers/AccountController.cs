using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc_ticket_theater.Data;
using mvc_ticket_theater.Data.Static;
using mvc_ticket_theater.Data.ViewModels;
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
        public IActionResult Login()
        {

            return View(new LoginVM());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) 
                return View(loginVM);

         

            var user = await userManager.FindByEmailAsync(loginVM.EmailAdress);

            if (user ! == null)
            {
                var passwordCheck = await userManager.CheckPasswordAsync(user, loginVM.Password);
                if(passwordCheck){
                    var result = await signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if(result.Succeeded)
                    { return RedirectToAction("Index", "Theaters");
                    }
                }
                TempData["Error"] = "Girilen Bilgiler Yanlış!";
                return View(loginVM);
            }
            TempData["Error"] = "Girilen Bilgiler Yanlış!";
            return View(loginVM);
        }


        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await userManager.FindByEmailAsync(registerVM.EmailAdress);
            if (user != null)
            {
                TempData["Error"] = "Email Adresi Sistemde Var";
                return View(registerVM);
            }

            var newUser = new AppUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAdress,
                UserName = registerVM.EmailAdress
            };
            var newUserResponse = await userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
                await userManager.AddToRoleAsync(newUser, UserRoles.User);

            return View("RegisterCompleted");
        }

    }
}
