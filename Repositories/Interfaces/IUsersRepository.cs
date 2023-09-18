using Blog.Models.Home;
using Blog.Entities;

namespace Blog.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        void Register(RegisterVM model);
        User Login(LoginVM model);
    }
}
