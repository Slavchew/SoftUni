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
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}