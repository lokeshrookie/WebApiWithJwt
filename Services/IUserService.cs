using JWT.API_.Models;

namespace JWT.API_.Services
{
    public interface IUserService
    {
        String Login(User user);
    }
}
