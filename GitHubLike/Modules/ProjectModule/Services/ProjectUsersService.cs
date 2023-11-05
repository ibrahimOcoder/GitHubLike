using GitHubLike.Modules.Common.Repository;
using GitHubLike.Modules.ProjectModule.Entity;
using GitHubLike.Modules.ProjectModule.Repository;
using Microsoft.EntityFrameworkCore;

namespace GitHubLike.Modules.ProjectModule.Services
{
    public class ProjectUsersService : IProjectUsersService
    {
        private readonly IRepository<ProjectUsers> _projectUsersRepository;

        public ProjectUsersService(IRepository<ProjectUsers> projectUsersRepository)
        {
            _projectUsersRepository = projectUsersRepository;
        }

        public async Task<ProjectUsers> GetProjectUser(long userId, long projectId)
        {
            return await _projectUsersRepository.Query()
                .FirstOrDefaultAsync(p => p.UserId == userId && p.ProjectId == projectId);
        }

        public async Task<int> AddProjectUser(ProjectUsers projectUser)
        {
            await _projectUsersRepository.Add(projectUser);
            return await _projectUsersRepository.SaveChanges();
        }

        public async Task<int> UpdateProjectUserRole(ProjectUsers projectUser)
        {
            _projectUsersRepository.Update(projectUser);
            return await _projectUsersRepository.SaveChanges();
        }

        public async Task<int> DeleteProjectUser(ProjectUsers projectUser)
        {
            _projectUsersRepository.Remove(projectUser);
            return await _projectUsersRepository.SaveChanges();
        }
    }
}
