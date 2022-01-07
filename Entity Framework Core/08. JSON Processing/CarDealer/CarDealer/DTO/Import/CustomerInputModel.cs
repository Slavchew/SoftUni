using System;

namespace CarDealer.DTO.Import
{
    public class CustomerInputModel
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
