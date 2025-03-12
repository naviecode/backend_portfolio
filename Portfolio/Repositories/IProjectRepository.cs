using Portfolio.Models;
using Portfolio.ViewModel;

namespace Portfolio.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>?> getAll();
        Task<Project?> getById(int projectId);
        Task<Project?> add(ProjectInsVM project);
        Task<bool> update(ProjectUpdVM project);
        Task<bool> delete(int projectId);
    }
}
