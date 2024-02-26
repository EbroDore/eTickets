using eTickets.Data;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
	public class AccountController : Controller
	{

		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		public AccountController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;

		}

        public IActionResult Login() => View(new LoginVM());

		[HttpPost]
		public async Task<IActionResult> Login(LoginVM loginVM)
		{ 
			if(!ModelState.IsValid) return View(loginVM);

			var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
			if(user != null)
			{
				var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
				if (passwordCheck)
				{
					var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
					if (result.Succeeded)
					{
						return RedirectToAction("Index", "Movie");
					}
				}
                TempData["Error"] = "Wrong Credentials. Please trying again";
                return View(loginVM);
            }

			TempData["Error"] = "Wrong Credentials. Please trying again";
			return View(loginVM);

        }

	}
}
