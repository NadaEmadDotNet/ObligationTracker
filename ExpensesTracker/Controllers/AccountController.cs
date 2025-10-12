using ExpensesTracker.Models;
using ExpensesTracker.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Threading.Tasks;

namespace ExpensesTracker.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager; //دي بتتيح ليا الخصاؤص اللي تخص اليوزر والمثودز
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveRegister(RegisterVm registerVm)
        {
            var appuser = new ApplicationUser()
            {
                UserName = registerVm.UserName,
                Email = registerVm.Email,
            };
            var result = await userManager.CreateAsync(appuser, registerVm.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(appuser, false);
                return RedirectToAction("LogIn", "Account");

            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View("Register", registerVm);
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> SaveLogIn(LogInVM logInVM)
        {
            if (!ModelState.IsValid)
                return View("LogIn", logInVM);

            var user = await userManager.FindByNameAsync(logInVM.Name);
            if (user == null)
            {
                ModelState.AddModelError("", "User not found. Please register first.");
                return View("LogIn", logInVM);
            }

            // تسجيل الدخول والتحقق في خطوة واحدة
            var result = await signInManager.PasswordSignInAsync(
                logInVM.Name,
                logInVM.Password,
                logInVM.RememberMe,
                lockoutOnFailure: false
            );

            if (result.Succeeded)
            {
                return RedirectToAction("AddObligation", "Obligation");
            }

            ModelState.AddModelError("", "The username or password is incorrect");
            return View("LogIn", logInVM);
        }


        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return View("LogIn");
        }
    }
}