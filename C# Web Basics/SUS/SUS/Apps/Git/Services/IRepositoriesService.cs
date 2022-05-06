using System.Collections.Generic;

using Git.Data;
using Git.ViewModels.Repositories;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        IEnumerable<RepositoryViewModel> GetAll(string userId);

        void Create(string name, string type, string userId);

        RepositoryViewModel GetRepositoryById(string id);
    }
}
