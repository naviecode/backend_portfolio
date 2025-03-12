using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.ViewModel;

namespace Portfolio.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly PortfolioDbContext _context;
        public ProjectRepository(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<Project?> add(ProjectInsVM project)
        {
            Project projectIns = new Project
            {
                UserId = project.UserId,
                Title = project.Title,
                Description = project.Description,
                Technologies = project.Technologies,
                GitHubLink = project.GitHubLink,
                DemoLink = project.DemoLink,
                Image = project.Image
            };

            await _context.Projects.AddAsync(projectIns);
            await _context.SaveChangesAsync();

            return projectIns;
        }

        public async Task<bool> delete(int projectId)
        {
            var projectFindId = await _context.Projects.FindAsync(projectId);
            
            if (projectFindId == null)
            {
                throw new Exception("Project not found");
            }

            _context.Projects.Remove(projectFindId);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Project>?> getAll()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project?> getById(int projectId)
        {
            var projectFindId = await _context.Projects.FindAsync(projectId);

            if (projectFindId == null)
            {
                throw new Exception("Project not found");
            }

            return projectFindId;
        }

        public async Task<bool> update(ProjectUpdVM project)
        {
            var projectFindId = await _context.Projects.FindAsync(project.Id);

            if (projectFindId == null)
            {
                throw new Exception("Project not found");
            }
            Project projectUpd = new Project
            {
                Id = project.Id,
                UserId = project.UserId,
                Title = project.Title,
                Description = project.Description,
                Technologies = project.Technologies,
                GitHubLink = project.GitHubLink,
                DemoLink = project.DemoLink,
                Image = project.Image
            };

            _context.Projects.Update(projectUpd);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
