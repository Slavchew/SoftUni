using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class Breed
    {
        public Breed()
        {
            this.Pets = new HashSet<Pet>();
        }

        [Key]
        [MinLength(3)]
        [MaxLength(100)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
