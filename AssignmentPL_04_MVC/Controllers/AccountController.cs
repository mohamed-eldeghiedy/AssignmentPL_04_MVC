using AssignmentDAL.Entities;
using AssignmentPL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentPL.Controllers
{
    public class AccountController(UserManager<ApplcationUser> userManager,
            SignInManager<ApplcationUser> signInManager)
        : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerView)
        {
            if (!ModelState.IsValid)
                return View(registerView);
            var user = new ApplcationUser
            {
                FirstName = registerView.FirstName,
                LastName = registerView.LastName,
                UserName = registerView.UserName,
                Email = registerView.Email
            };
            var result = await userManager.CreateAsync(user, registerView.Password);
            if (!result.Succeeded)
                return RedirectToAction("Login");
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(registerView);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Login(LoginViewModel loginView)
        {
            if(!ModelState.IsValid) 
                return View(loginView);

            var user = await userManager.FindByEmailAsync(loginView.Email);
            if(user != null)
            {
                if(await userManager.CheckPasswordAsync(user, loginView.Password))
                {
                    var result = await signInManager.PasswordSignInAsync(user, loginView.Password, loginView.RememberMe, false);
                    if (result.Succeeded)
                         return RedirectToAction("Index", "Home");
                }

            }
            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");


            return View(loginView);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction( "Index","Home");
        }
    }
}
