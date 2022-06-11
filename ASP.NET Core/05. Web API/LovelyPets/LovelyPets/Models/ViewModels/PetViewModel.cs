namespace LovelyPets.Models.ViewModels
{
    using LovelyPets.Data.Models.Enums;

    public class PetViewModel
    {
        public string Name { get; set; }

        public Type Type { get; set; }

        public int Love { get; set; }
        
        public string OwnerName { get; set; }
    }
}