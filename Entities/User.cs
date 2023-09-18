using System.ComponentModel.DataAnnotations;

namespace Blog.Entities
{
	public class User
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 2)]
		public string FirstName { get; set; }

		[StringLength(50, MinimumLength = 2)]
		public string LastName { get; set; }

		[Required]
		[StringLength(100, MinimumLength = 2)]
		public string Email { get; set; }

		[Required]
		[StringLength(500, MinimumLength = 2)]
		public string Password { get; set; }

		public DateTime DateCreated { get; set; }

		public IEnumerable<Post> Posts { get; set; }
	}
}
