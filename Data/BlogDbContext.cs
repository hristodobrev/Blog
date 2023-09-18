using Microsoft.EntityFrameworkCore;
using Blog.Entities;

namespace Blog.Data
{
	public class BlogDbContext : DbContext
	{
		private readonly IConfiguration configuration;
		public BlogDbContext(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Tag> Tags { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("Default"));
		}
	}
}
