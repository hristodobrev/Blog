using Blog.Data;
using Blog.Entities;
using Blog.Models.Posts;
using Blog.Repositories.Interfaces;

namespace Blog.Repositories.Implementations
{
	public class PostsRepository : IPostsRepository
	{
		private readonly BlogDbContext dbContext;

		public PostsRepository(BlogDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public void Add(AddPostVM model)
		{
			this.dbContext.Posts.Add(new Post
			{
				Title = model.Title,
				Body = model.Body,
				DateCreated = DateTime.Now,
				Author = model.Author
			});

			this.dbContext.SaveChanges();
		}

		public IEnumerable<Post> GetAll()
		{
			return this.dbContext.Posts.ToList();
		}
	}
}
