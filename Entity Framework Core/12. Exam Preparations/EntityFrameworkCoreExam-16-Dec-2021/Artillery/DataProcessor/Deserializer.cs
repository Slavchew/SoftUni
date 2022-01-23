namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();

            var countries = XmlConverter.Deserializer<CountryXmlInputModel>(xmlString, "Countries");
            foreach (var xmlCountry in countries)
            {
                if (!IsValid(xmlCountry))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Country country = new Country
                {
                    CountryName = xmlCountry.CountryName,
                    ArmySize = xmlCountry.ArmySize,
                };

                context.Countries.Add(country);
                context.SaveChanges();
                output.AppendLine(String.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();

            var manufacturers = XmlConverter.Deserializer<ManufacturerXmlInputModel>(xmlString, "Manufacturers");
            foreach (var xmlManufacturer in manufacturers)
            {
                var isExist = context.Manufacturers.Any(x => x.ManufacturerName == xmlManufacturer.ManufacturerName);

                if (!IsValid(xmlManufacturer) || isExist)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Manufacturer manufacturer = new Manufacturer
                {
                    ManufacturerName = xmlManufacturer.ManufacturerName,
                    Founded = xmlManufacturer.Founded,
                };

                var foundedInfo = manufacturer.Founded.Split(", ");
                var town = foundedInfo[foundedInfo.Length - 2];
                var country = foundedInfo[foundedInfo.Length - 1];
                var outputFounded = $"{town}, {country}";

                context.Manufacturers.Add(manufacturer);
                context.SaveChanges();
                output.AppendLine(String.Format(SuccessfulImportManufacturer, 
                    manufacturer.ManufacturerName,
                    outputFounded));
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();

            var shells = XmlConverter.Deserializer<ShellXmlInputModel>(xmlString, "Shells");
            foreach (var xmlshell in shells)
            {
                if (!IsValid(xmlshell))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Shell shell = new Shell
                {
                    ShellWeight = xmlshell.ShellWeight,
                    Caliber = xmlshell.Caliber,
                };

                context.Shells.Add(shell);
                context.SaveChanges();
                output.AppendLine(String.Format(SuccessfulImportShell, 
                    shell.Caliber,
                    shell.ShellWeight));
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            var guns = JsonConvert.DeserializeObject<IEnumerable<GunInputModel>>(jsonString);

            foreach (var jsonGun in guns)
            {
                bool isValidGunType = Enum.TryParse<GunType>(jsonGun.GunType, out GunType gunType);

                if (!IsValid(jsonGun) || !isValidGunType)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Gun gun = new Gun
                {
                    ManufacturerId = jsonGun.ManufacturerId,
                    GunWeight = jsonGun.GunWeight,
                    BarrelLength = jsonGun.BarrelLength,
                    NumberBuild = jsonGun.NumberBuild,
                    Range = jsonGun.Range,
                    GunType = gunType,
                    ShellId = jsonGun.ShellId,
                    CountriesGuns = jsonGun.Countries.Select(c => new CountryGun
                    {
                        CountryId = c.Id
                    })
                    .ToList()
                };

                context.Guns.Add(gun);
                context.SaveChanges();
                output.AppendLine(String.Format(SuccessfulImportGun, 
                    gun.GunType.ToString(), 
                    gun.GunWeight, 
                    gun.BarrelLength));
            }

            return output.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
