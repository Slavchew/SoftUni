namespace LovelyPets.Data.Models
{
    using Enums;

    public class Pet
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Type Type { get; set; }

        public int Loved { get; set; }

        public string OwnerId { get; set; }

        public User Owner { get; set; }
    }
}