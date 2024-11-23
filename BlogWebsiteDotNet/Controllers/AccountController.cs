using BlogWebsiteDotNet.Data;
using BlogWebsiteDotNet.Models;
using BlogWebsiteDotNet.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogWebsiteDotNet.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
		private readonly AppDbContext _context;
		public AccountController(SignInManager<User> _signInManager, UserManager<User> _userManager, AppDbContext dbContext)
        {
            this._signInManager = _signInManager;
            this._userManager = _userManager;
			_context = dbContext;
		}

		public IActionResult Index()
        {
            return View("LogIn");
        }
        [HttpGet]
        public async Task<IActionResult> LogIn()
        {
            return View();
        }
        [HttpPost]
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
        [HttpGet]
		public async Task<IActionResult> Register()
		{
            return View("Register");
		}
        public async Task<IActionResult> Register(RegisterVM viewModel)
        {
            //if (ModelState.IsValid) {
            User user = new()
            {
                UserName = viewModel.UserName,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                EmailConfirmed=false,
                PhoneNumberConfirmed=false,
                TwoFactorEnabled=false,
                LockoutEnabled=false,
                AccessFailedCount=0,
            };
            var result= await _userManager.CreateAsync(user, viewModel.Password);
            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "Commenter");
                if (roleResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(viewModel);
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Profile(string id)
        {
			var user = await _userManager.FindByIdAsync(id);

			var userVM = new UserVM
			{
                UserId = id,
				UserName = user.UserName,
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
			};
			return View(userVM);
        }
        public async Task<IActionResult> EditProfile(UserVM userEdit)
        {
			var user= await _userManager.FindByIdAsync(userEdit.UserId);

			await _userManager.SetEmailAsync(user, userEdit.Email);
			await _userManager.SetPhoneNumberAsync(user, userEdit.PhoneNumber);

            if (userEdit.Password != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, token, userEdit.Password!);
            }

			await _userManager.UpdateAsync(user);

			return View("Profile");
		}

        public async Task<IActionResult> requestAuthorStatus(string id)
        {
			var user = await _userManager.FindByIdAsync(id);
            var newReq = new StatusRequest
            {
                UserId=user.Id,
				requestStatus= "Pending"
			};
			_context.StatusRequests.Add(newReq);
			await _context.SaveChangesAsync();
			return RedirectToAction("Profile","Account", new { id });
        }
    }

}
