using AutoMapper;
using GitHubLike.Modules.WorkspaceModule.Entity;
using GitHubLike.Modules.WorkspaceModule.Models;

namespace GitHubLike.Modules.WorkspaceModule.Mappings
{
    public class WorkspaceCreateProfile: Profile
    {
        public WorkspaceCreateProfile() {
            CreateMap<WorkspaceCreateDto, Workspace>();
        }
    }
}
