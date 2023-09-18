using Blog.Entities;
using Blog.Extensions;
using Blog.Models.Home;
using Blog.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
	public class HomeController : Controller
	{
		private readonly IUsersRepository userRepository;

		public HomeController(IUsersRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(LoginVM model)
		{
			User user = this.userRepository.Login(model);
			if (user != null)
			{
				this.HttpContext.Session.SetObject("User", user);
				return RedirectToAction("Index", "Home");
			}

			TempData["Message"] = "Invalid credentials. Please try again.";

			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(RegisterVM model)
		{
			if (model.Password != model.ConfirmPassword)
			{
				TempData["Message"] = "Passwords do not match!";
			}
			else
			{
				this.userRepository.Register(model);
				return RedirectToAction("Index", "Home");
			}

			return View();
		}

		public IActionResult Logout()
		{
			this.HttpContext.Session.Remove("User");

			return RedirectToAction("Index", "Home");
		}
	}
}