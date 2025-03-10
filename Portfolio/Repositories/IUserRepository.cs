using Portfolio.ViewModel;

namespace Portfolio.Repositories
{
    public interface IUserRepository
    {
        Task<string> Login(LoginVM loginVM);
        Task<string> RefreshToken(RefreshVM refreshVM);
        Task<string> Logout(LogoutVM logoutVM);
        Task<string> LogoutAllDevice(int userId);
    }
}
