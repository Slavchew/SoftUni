using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class ClientProduct
    {
        [Required]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }

        [Required]
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
