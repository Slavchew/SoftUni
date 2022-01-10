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
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MinLength(6)]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public virtual ICollection<Pet> PetsBought { get; set; }
    }
}
