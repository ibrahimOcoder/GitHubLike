using GitHubLike.Modules.Common.Repository;
using GitHubLike.Modules.ProjectModule.Entity;
using GitHubLike.Modules.ProjectModule.Models;
using GitHubLike.Modules.ProjectModule.Repository;
using Microsoft.EntityFrameworkCore;

namespace GitHubLike.Modules.ProjectModule.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Projects> _projectRepository;
        private readonly IRepository<ProjectUsers> _projectUsersRepository;

        public ProjectService(IRepository<Projects> projectRepository, IRepository<ProjectUsers> projectUsersRepository)
        {
            _projectRepository = projectRepository;
            _projectUsersRepository = projectUsersRepository;
        }

        public async Task AddProject(Projects project)
        {
            await _projectRepository.Add(project);
            await _projectRepository.SaveChanges();
        }

        public async Task<Projects> GetProject(long projectId)
        {
            return await _projectRepository.Query().SingleOrDefaultAsync(p => p.Id == projectId);
        }

        public async Task<IQueryable<Projects>> GetProjectsByOwner(long ownerId)
        {
            return _projectRepository.Query().Where(p => p.OwnerId == ownerId).AsNoTracking();
        }

        public async Task<IQueryable<ProjectUserInvitationsViewDto>> GetProjectsByOwnerWithInvitations(long userId)
        {
            return _projectRepository.Query().Join(_projectUsersRepository.Query().Where(p => p.UserId == userId && p.AcceptedInvite == false), 
                projects => projects.Id,
                projectUsers => projectUsers.ProjectId,
                (projects, projectUsers) => new ProjectUserInvitationsViewDto
                {
                    InviteAccepted = projectUsers.AcceptedInvite,
                    Project = new ProjectViewDto { ProjectId = projects.Id, ProjectName = projects.ProjectName }
                }).AsNoTracking();
        }

        public async Task<IQueryable<ProjectViewDto>> GetProjectsByOrganizationandUser(long organizationId, long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateProject(Projects project)
        {
            _projectRepository.Update(project);
            return await _projectRepository.SaveChanges();
        }

        public async Task<int> DeleteProject(Projects project)
        {
            _projectRepository.Remove(project);
            return await _projectRepository.SaveChanges();
        }
    }
}
