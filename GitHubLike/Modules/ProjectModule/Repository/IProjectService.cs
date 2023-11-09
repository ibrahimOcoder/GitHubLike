using GitHubLike.Modules.ProjectModule.Models;
using GitHubLike.Modules.ProjectModule.Entity;

namespace GitHubLike.Modules.ProjectModule.Repository
{
    public interface IProjectService
    {
        Task AddProject(Projects Project);

        Task<Projects> GetProject(long ProjectId);

        // Get Projects by User
        Task<IQueryable<Projects>> GetProjectsByOwner(long ownerId);

        // Get Projects by User with invitation details
        Task<IQueryable<ProjectUserInvitationsViewDto>> GetProjectsByOwnerWithInvitations(long ownerId);
        
        // Get Projects by Organization & User
        Task<IQueryable<ProjectViewDto>> GetProjectsByOrganizationandUser(long organizationId, long userId);

        Task<ProjectDetailViewDto> GetProjectDetails(long projectId);

        Task<int> UpdateProject(Projects Project);

        Task<int> DeleteProject(Projects Project);
    }
}
