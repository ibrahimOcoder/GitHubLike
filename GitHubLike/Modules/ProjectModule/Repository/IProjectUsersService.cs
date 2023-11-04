using GitHubLike.Modules.ProjectModule.Entity;

namespace GitHubLike.Modules.ProjectModule.Repository
{
    public interface IProjectUsersService
    {
        Task<ProjectUsers> GetProjectUser(long userId, long projectId);

        Task<int> AddProjectUser(ProjectUsers ProjectUser);

        Task<int> UpdateProjectUserRole(ProjectUsers project);

        Task<int> DeleteProjectUser(ProjectUsers ProjectUser);
    }
}
