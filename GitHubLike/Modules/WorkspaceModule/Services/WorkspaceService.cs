using GitHubLike.Modules.Common.Entity;
using GitHubLike.Modules.Common.Repository;
using GitHubLike.Modules.WorkspaceModule.Entity;
using GitHubLike.Modules.WorkspaceModule.Repository;

namespace GitHubLike.Modules.WorkspaceModule.Services
{
    public class WorkspaceService : IWorkspaceService
    {
        private readonly IRepository<Workspace> _workspaceRepository;

        public WorkspaceService(IRepository<Workspace> workspaceRepository)
        {
            _workspaceRepository = workspaceRepository;
        }

        public async Task AddWorkSpace(Workspace workspace)
        {
            await _workspaceRepository.Add(workspace);
            await _workspaceRepository.SaveChanges();
        }
    }
}
