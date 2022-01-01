using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using trekkingadventurescr.Models;
using trekkingadventurescr.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace trekkingadventurescr.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		private UserManager<User> _UserManager;
		private SignInManager<User> _SignInManager;
		private readonly IConfiguration _configuration;

		public AccountController(UserManager<User> UserManager, SignInManager<User> SignInManager, IConfiguration configuration)
		{
			_UserManager = UserManager;
			_SignInManager = SignInManager;
			_configuration = configuration;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> LogIn(string ReturnUrl = null)
		{
			ViewBag.ReturnUrl = ReturnUrl;
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> LogIn(LogInViewModel viewModelData, string returnUrl)
		{
			returnUrl = returnUrl ?? Url.Content("~/");

			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Invalid data.");
				return View(viewModelData);
			}

			try
			{
				User user = await _UserManager.FindByNameAsync(viewModelData.username);

				if (user is null) throw new Exception("User not found");

				var result = await _SignInManager.PasswordSignInAsync(viewModelData.username, viewModelData.password, isPersistent: true, lockoutOnFailure: false);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Tours");
				}
			}
			catch
			{
				ModelState.AddModelError(string.Empty, "An error has ocurred while loggin in.");
			}

			return View(viewModelData);
		}

		private IActionResult RedirectToLocal(string ReturnUrl)
		{
			if (Url.IsLocalUrl(ReturnUrl))
			{
				return Redirect(ReturnUrl);
			}
			return RedirectToAction("Index", "Home");
		}

		private void AddErrors(IdentityResult Result)
		{
			foreach (IdentityError error in Result.Errors)
			{
				ModelState.AddModelError("", error.Description);
			}
		}
	}
}