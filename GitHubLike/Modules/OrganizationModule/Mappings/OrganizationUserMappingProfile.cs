using AutoMapper;
using GitHubLike.Modules.OrganizationModule.Entity;
using GitHubLike.Modules.OrganizationModule.Models;

namespace GitHubLike.Modules.OrganizationModule.Mappings
{
    public class OrganizationUserMappingProfile : Profile
    {
        public OrganizationUserMappingProfile()
        {
            CreateMap<OrganizationUserCreateDto, OrganizationUsers>();

            CreateMap<OrganizationUserUpdateDto, OrganizationUsers>();

            CreateMap<OrganizationUserDeleteDto, OrganizationUsers>();
        }
    }
}
