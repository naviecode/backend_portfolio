using Portfolio.Models;
using Portfolio.Repositories;
using Portfolio.ViewModel;

namespace Portfolio.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Project?> add(ProjectInsVM project)
        {
            return await _projectRepository.add(project);
        }
        public async Task<bool> delete(int projectId)
        {
            return await _projectRepository.delete(projectId);
        }
        public async Task<IEnumerable<Project>?> getAll()
        {
            return await _projectRepository.getAll();
        }
        public async Task<Project?> getById(int projectId)
        {
            return await _projectRepository.getById(projectId);
        }
        public async Task<bool> update(ProjectUpdVM project)
        {
            return await _projectRepository.update(project);
        }
    }
}
