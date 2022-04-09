namespace BattleCards.Services
{
    public interface IUsersService
    {
        string CreateUser(string username, string email, string password);

        bool IsEmailAvailable(string email);

        bool IsUsernameAvailable(string username);

        string GetUserId(string username, string password);
    }
}
