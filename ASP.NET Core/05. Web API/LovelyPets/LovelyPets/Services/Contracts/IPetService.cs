namespace LovelyPets.Services.Contracts
{
    using Models.InputModels;
    using Models.ViewModels;
    using System.Collections.Generic;

    public interface IPetService
    {
        IEnumerable<string> All();

        PetViewModel Create(CreatePetBindingModel model, string userId);

        PetViewModel GiveLove(string name, string userId);

        string Delete(string name, string userId);
    }
}