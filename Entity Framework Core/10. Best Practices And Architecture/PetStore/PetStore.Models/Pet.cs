using System;
using System.ComponentModel.DataAnnotations;
using PetStore.Common;
using PetStore.Models.Enumerations;

namespace PetStore.Models
{
    public class Pet
    {
        public Pet()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PetNameMaxLength)]
        public string Name { get; set; }

        public byte Age { get; set; }

        public Gender Gender { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public bool IsSold { get; set; }

        public int BreedId { get; set; }

        public virtual Breed Breed { get; set; }

        public string ClientId { get; set; }

        public virtual Client Client { get; set; }

    }
}
