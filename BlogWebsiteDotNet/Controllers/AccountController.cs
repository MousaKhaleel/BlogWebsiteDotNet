using BlogWebsiteDotNet.Models;
using BlogWebsiteDotNet.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsiteDotNet.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        public AccountController(SignInManager<User> _signInManager)
        {
            this._signInManager = _signInManager;
        }
        public IActionResult Index()
        {
            return View("LogIn");
        }
        public async Task<IActionResult> LogIn(LogInVM viewModel)
        {
            var result= await _signInManager.PasswordSignInAsync(viewModel.UserName, viewModel.Password, viewModel.rememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View(viewModel);
            }
        }
    }

}
