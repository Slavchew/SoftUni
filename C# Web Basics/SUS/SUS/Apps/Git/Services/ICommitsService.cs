using System.Collections.Generic;

using Git.ViewModels.Commits;

namespace Git.Services
{
    public interface ICommitsService
    {
        IEnumerable<CommitViewModel> GetAll(string userId);

        void Create(string description, string repositoryId, string userId);

        CommitViewModel GetCommitById(string id);

        void Delete(string id);
    }
}
