using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Store.Data;
using Store.Repository;
using Store.ViewModels;
using Store.Models;

namespace Store.Controllers
{
	public class AccountController : Controller
	{
		private MyDBShopContext _db;
		private IUserRepository _userRepository;

		public AccountController(MyDBShopContext db,IUserRepository userRepository)
		{
			_db = db;
			_userRepository = userRepository;
		}

		public ActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			if (_userRepository.IsExistedUserByEmail(model.Email.ToLower()))
			{
				ModelState.AddModelError("Email", "ایمیل وارد شده قبلا ثبت نام کرده است");
				return View(model);
			}
			User user = new User()
			{
				Email = model.Email,
				Password = model.Password,
				UserId=model.Id
			};
			_db.User.Add(user);
			_db.SaveChanges();
			return RedirectToAction("Index", "Home");
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var user = _userRepository.GetUserForLoggin(model.Email, model.Password);
			if (user == null)
			{
				ModelState.AddModelError("Email", "ایمیل وارد شده یافت نشد");
				return View(model);
			}
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
				new Claim(ClaimTypes.Name, user.Email),
				// new Claim("CodeMeli", user.Email),

			};
			var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

			var principal = new ClaimsPrincipal(identity);

			var properties = new AuthenticationProperties
			{
				IsPersistent = model.RememberMe
			};

			HttpContext.SignInAsync(principal, properties);

			return Redirect("/");

		}

		public IActionResult Logout()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return Redirect("/");
		}
	}
}

