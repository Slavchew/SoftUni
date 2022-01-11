using System.ComponentModel.DataAnnotations;

using PetStore.Common;
using PetStore.Models.Enumerations;

namespace PetStore.ServiceModels.Products.Input
{
    public class AddProductInputServiceModel
    {
        [Required]
        [MinLength(GlobalConstants.ProductNameMinLength)]
        [MaxLength(GlobalConstants.ProductNameMaxLength)]
        public string Name { get; set; }

        public string ProductType { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
