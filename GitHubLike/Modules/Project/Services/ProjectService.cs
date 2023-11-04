using GitHubLike.Modules.Common.Repository;
using GitHubLike.Modules.Project.Entity;
using GitHubLike.Modules.RoleModule.Entity;

namespace GitHubLike.Modules.Project.Services
{
    public class ProjectService
    {
        private readonly IRepository<Projects> _projectRepository;

        public ProjectService(IRepository<Projects> projectRepository)
        {
            _projectRepository = projectRepository;
        }
    }
}
