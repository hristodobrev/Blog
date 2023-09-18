using Blog.Entities;
using Blog.Extensions;
using Blog.Models.Posts;
using Blog.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
	public class PostsController : Controller
	{
		private readonly IPostsRepository postsRepository;
		public PostsController(IPostsRepository postsRepository)
		{
			this.postsRepository = postsRepository;
		}

		public IActionResult Index()
		{
			IEnumerable<Post> posts = this.postsRepository.GetAll();

			return View(posts);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(AddPostVM model)
		{
			model.Author = this.HttpContext.Session.GetObject<User>("User");

			this.postsRepository.Add(model);

			return RedirectToAction("Index", "Posts");
		}
	}
}
