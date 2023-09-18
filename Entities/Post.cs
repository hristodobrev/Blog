using System.ComponentModel.DataAnnotations;

namespace Blog.Entities
{
	public class Post
	{
		public int Id { get; set; }

		[Required]
		[StringLength(200)]
		public string Title { get; set; }

		[Required]
		[StringLength(2000)]
		public string Body { get; set; }

		public DateTime DateCreated { get; set; }

		public User Author { get; set; }
		public IEnumerable<Tag> Tags { get; set; }
	}
}
