using AutoMapper;
using GitHubLike.Modules.Project.Repository;
using GitHubLike.Modules.RoleModule.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitHubLike.Modules.Project.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProjectService _projectService;

        public ProjectsController(IMapper mapper, IProjectService projectService)
        {
            _mapper = mapper;
            _projectService = projectService;
        }


    }
}

