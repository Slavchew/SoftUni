namespace LovelyPets.Services.Implementations
{
    using Contracts;
    using Data;
    using LovelyPets.Data.Models;
    using Models.InputModels;
    using Models.ViewModels;
    using System.Collections.Generic;
    using System.Linq;

    public class PetService : IPetService
    {
        private readonly LovelyPetsDbContext context;

        public PetService(LovelyPetsDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<string> All()
        {
            var pets = this.context
                .Pets
                .Select(p => p.Name)
                .ToList();

            return pets;
        }
        public PetViewModel Create(CreatePetBindingModel model, string userId)
        {
            var owner = this.context
                .Users
                .FirstOrDefault(u => u.Id == userId);

            if (owner == null)
            {
                return null;
            }

            var pet = new Pet()
            {
                Name = model.Name,
                Type = model.Type,
                Owner = owner,
                OwnerId = owner.Id
            };

            this.context.Pets.Add(pet);
            this.context.SaveChanges();

            var petModel = new PetViewModel()
            {
                Name = pet.Name,
                Type = pet.Type,
                Love = pet.Loved,
                OwnerName = pet.Owner.Username
            };

            return petModel;
        }

        public PetViewModel GiveLove(string name, string userId)
        {
            var userExists = this.context
                .Users
                .Any(u => u.Id == userId);

            if (!userExists)
            {
                return null;
            }

            var pet = this.context
                .Pets
                .FirstOrDefault(p => p.Name == name);

            if (pet == null)
            {
                return null;
            }

            pet.Loved++;
            this.context.SaveChanges();

            // TODO - Fix
            var ownerName = this.context
                .Users
                .FirstOrDefault(u => u.Id == pet.OwnerId)
                .Username;

            var petModel = new PetViewModel()
            {
                Name = pet.Name,
                Type = pet.Type,
                Love = pet.Loved,
                OwnerName = ownerName
            };

            return petModel;
        }

        public string Delete(string name, string userId)
        {
            var pet = this.context
                .Pets
                .FirstOrDefault(p => p.Name == name 
                                     && p.Owner.Id == userId);

            if (pet == null)
            {
                return null;
            }

            var petName = pet.Name;
            this.context.Pets.Remove(pet);
            this.context.SaveChanges();

            return petName;
        }
    }
}