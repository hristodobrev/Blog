using Blog.Data;
using Blog.Models.Home;
using Blog.Repositories.Interfaces;
using Blog.Entities;

namespace Blog.Repositories.Implementations
{
    public class UsersRepository : IUsersRepository
    {
        private readonly BlogDbContext dbContext;

        public UsersRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Register(RegisterVM model)
        {
            this.dbContext.Users.Add(new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password, BCrypt.Net.BCrypt.GenerateSalt(10)),
                DateCreated = DateTime.Now
            });

            this.dbContext.SaveChanges();
        }

        public User Login(LoginVM model)
        {
            User user = this.dbContext.Users.FirstOrDefault(u => u.Email == model.Email);
            if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                user.Password = null;
                return user;
            }

            return null;
        }
    }
}
