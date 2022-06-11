namespace LovelyPets.Services.Contracts
{
    using LovelyPets.Data.Models;

    using Models.InputModels;
    using Models.ViewModels;

    public interface IUserService
    {
        UserViewModel CreateUser(RegisterUserBindingModel user, string newEmail);

        string Authenticate(string username, string password);

        User DeleteUserByUsername(string username);
    }
}