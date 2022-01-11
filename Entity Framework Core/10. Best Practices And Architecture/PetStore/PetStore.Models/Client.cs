using PetStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class Client
    {
        public Client()
        {
            this.Id = Guid.NewGuid().ToString();

            this.PetsBought = new HashSet<Pet>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.ClientUsernameMinLength)]
        [MaxLength(GlobalConstants.ClientUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MinLength(GlobalConstants.ClientEmailMinLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ClientFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ClientLastNameMaxLength)]
        public string LastName { get; set; }

        public virtual ICollection<Pet> PetsBought { get; set; }
    }
}
