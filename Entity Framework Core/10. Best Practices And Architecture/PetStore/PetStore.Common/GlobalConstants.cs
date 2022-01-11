namespace PetStore.Common
{
    public static class GlobalConstants
    {
        // Breed
        public const int BreedNameMinLength = 5;
        public const int BreedNameMaxLength = 100;


        // Client
        public const int ClientUsernameMinLength = 6;
        public const int ClientUsernameMaxLength = 250;
        public const int ClientEmailMinLength = 6;
        public const int ClientFirstNameMaxLength = 6;
        public const int ClientLastNameMaxLength = 6;


        // Town
        public const int TownNameMinLength = 3;
        public const int TownNameMaxLength = 100;

        // Order
        public const int AddressMinLength = 5;
        public const int AddressMaxLength = 100;

        // Pet
        public const int PetNameMaxLength = 50;

        // Product
        public const int ProductNameMinLength = 3;
        public const int ProductNameMaxLength = 150;
    }
}
