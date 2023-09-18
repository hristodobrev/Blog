using Blog.Entities;

namespace Blog.Models.Posts
{
	public class AddPostVM
	{
		public string Title { get; set; }
		public string Body { get; set; }
		public User Author { get; set; }
	}
}
