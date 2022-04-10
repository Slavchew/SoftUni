namespace Suls.Services
{
    public interface IUsersService
    {
        void CrateUser(string username, string email, string password);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);
    }
}
