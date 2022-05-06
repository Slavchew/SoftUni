using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using Git.Data;
using Git.ViewModels.Commits;
using Git.ViewModels.Repositories;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string description, string repositoryId, string userId)
        {
            var commit = new Commit
            {
                Description = description,
                CreatedOn = DateTime.Now,
                CreatorId = userId,
                RepositoryId = repositoryId,
            };

            this.db.Commits.Add(commit);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var commit = this.db.Commits.Find(id);
            this.db.Commits.Remove(commit);
            this.db.SaveChanges();
        }

        public IEnumerable<CommitViewModel> GetAll(string userId)
        {
            return this.db.Commits.Where(x => x.CreatorId == userId)
                .Select(x => new CommitViewModel
                {
                    Id = x.Id,
                    Repository = x.Repository.Name,
                    Description = x.Description,
                    CreatedOn = x.CreatedOn,
                })
                .ToList();
        }

        public CommitViewModel GetCommitById(string id)
        {
            return this.db.Commits.Where(x => x.Id == id)
                .Select(x => new CommitViewModel
                {
                    Id = x.Id,
                    CreatorId = x.CreatorId
                    
                }).FirstOrDefault();
        }
    }
}