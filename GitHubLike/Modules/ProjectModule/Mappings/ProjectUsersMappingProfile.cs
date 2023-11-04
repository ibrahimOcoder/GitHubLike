using AutoMapper;
using GitHubLike.Modules.ProjectModule.Entity;
using GitHubLike.Modules.ProjectModule.Models;

namespace GitHubLike.Modules.ProjectModule.Mappings
{
    public class ProjectUsersMappingProfile : Profile
    {
        public ProjectUsersMappingProfile()
        {
            CreateMap<ProjectUserCreateDto, ProjectUsers>();
        }
    }
}
