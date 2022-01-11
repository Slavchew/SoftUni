using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PetStore.Common;

namespace PetStore.Models
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();

            this.ClientProducts = new HashSet<ClientProduct>();
        }

        [Key]
        public string Id { get; set; }

        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        [Required]
        [MinLength(GlobalConstants.AddressMinLength)]
        [MaxLength(GlobalConstants.AddressMaxLength)]
        public string Address { get; set; }

        public string Node { get; set; }

        public virtual ICollection<ClientProduct> ClientProducts { get; set; }

        [NotMapped]
        public decimal TotalPrice => this.ClientProducts.Sum(cp => cp.Product.Price * cp.Quantity);
    }
}
