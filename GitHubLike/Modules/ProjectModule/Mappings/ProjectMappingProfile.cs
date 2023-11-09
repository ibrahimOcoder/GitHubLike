using System.ComponentModel.Design;
using AutoMapper;
using GitHubLike.Modules.ProjectModule.Entity;
using GitHubLike.Modules.ProjectModule.Models;
using Microsoft.AspNetCore.Routing.Constraints;

namespace GitHubLike.Modules.ProjectModule.Mappings
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<Projects, ProjectViewDto>()
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.CreatedAt.Date)));
        }
    }
}
