using PetStore.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class Town
    {
        public Town()
        {
            this.Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.TownNameMinLength)]
        [MaxLength(GlobalConstants.TownNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}