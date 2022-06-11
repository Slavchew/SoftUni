namespace LovelyPets.Models.InputModels
{
    using LovelyPets.Data.Models.Enums;

    public class CreatePetBindingModel
    {
        public string Name { get; set; }

        public Type Type { get; set; }
    }
}