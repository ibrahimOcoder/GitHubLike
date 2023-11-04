using AutoMapper;
using GitHubLike.Modules.RoleModule.Entity;
using GitHubLike.Modules.RoleModule.Models;

namespace GitHubLike.Modules.RoleModule.Mappings
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<RoleCreateDto, Roles>();

            CreateMap<Roles, RoleViewDto>();

            CreateMap<RoleUpdateDto, Roles>();
        }
    }
}
