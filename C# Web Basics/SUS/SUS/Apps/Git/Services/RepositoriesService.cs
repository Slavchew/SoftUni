using System;
using System.Collections.Generic;
using System.Linq;

using Git.Data;
using Git.ViewModels.Repositories;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db, IUsersService usersService)
        {
            this.db = db;
        }

        public void Create(string name, string type, string userId)
        {
            var repository = new Repository
            {
                Name = name,
                CreatedOn = DateTime.Now,
                IsPublic = type == "Public" ? true : false,
                OwnerId = userId,
            };

            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
        }

        public IEnumerable<RepositoryViewModel> GetAll(string userId)
        {
            return this.db.Repositories.Where(x => x.IsPublic || x.OwnerId == userId)
                .Select(x => new RepositoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Owner = x.Owner.Username,
                    CreatedOn = x.CreatedOn,
                    CommitsCount = x.Commits.Count(),

                }).ToList();
        }

        public RepositoryViewModel GetRepositoryById(string id)
        {
            return this.db.Repositories.Where(x => x.Id == id)
                .Select(x => new RepositoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).FirstOrDefault();
        }
    }
}
