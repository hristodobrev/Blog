using Blog.Entities;
using Blog.Models.Posts;

namespace Blog.Repositories.Interfaces
{
	public interface IPostsRepository
	{
		IEnumerable<Post> GetAll();
		void Add(AddPostVM model);
	}
}
