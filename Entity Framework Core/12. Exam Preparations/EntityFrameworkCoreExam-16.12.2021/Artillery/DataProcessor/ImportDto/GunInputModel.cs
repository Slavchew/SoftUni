using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Artillery.DataProcessor.ImportDto
{
    public class GunInputModel
    {
        public int ManufacturerId { get; set; }

        [Range(100, 1_350_000)]
        public int GunWeight { get; set; }

        [Range(2.00d, 35.00d)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Range(1, 100_000)]
        public int Range { get; set; }

        public string GunType { get; set; }

        public int ShellId { get; set; }

        public ICollection<GunCountryInputModel> Countries { get; set; }
    }

    public class GunCountryInputModel
    {
        public int Id { get; set; }
    }
}
