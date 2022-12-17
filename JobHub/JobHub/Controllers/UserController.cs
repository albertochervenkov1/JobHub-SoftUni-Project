using JobHub.Infrastructure.Data.Models;
using JobHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobHub.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();

            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                EmailConfirmed = true,
                LastName = model.LastName,
                UserName = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Company", new { area = "Company" });
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }


            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Company", new { area = "Company" });
            }

            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.Email);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                

                if (result.Succeeded)
                {
                    if (await userManager.IsInRoleAsync(user,"Admin"))
                    {
                        return RedirectToAction("Index","Admin", new { area = "Admin" });
                    }
                    return RedirectToAction("Index", "Company",new { area = "Company" });
                }
            }

            ModelState.AddModelError("", "Invalid login");

            return View(model);
        }

        [Route("default")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
