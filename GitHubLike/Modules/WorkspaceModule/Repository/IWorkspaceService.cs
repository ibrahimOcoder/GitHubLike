using GitHubLike.Modules.WorkspaceModule.Entity;

namespace GitHubLike.Modules.WorkspaceModule.Repository
{
    public interface IWorkspaceService
    {
        Task AddWorkSpace(Workspace workspace);
    }
}
