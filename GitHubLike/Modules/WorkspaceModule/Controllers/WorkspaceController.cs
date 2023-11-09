using System.Net;
using AutoMapper;
using GitHubLike.Modules.WorkspaceModule.Models;
using GitHubLike.Modules.WorkspaceModule.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GitHubLike.Modules.WorkspaceModule.Controllers
{
    [Authorize]
    [Route("api/workspace")]
    [ApiController]
    public class WorkspaceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWorkspaceService _workspaceService;

        public WorkspaceController(IWorkspaceService workspaceService, IMapper mapper) {
            _workspaceService = workspaceService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post([FromBody] WorkspaceCreateDto createDto) {
            if (createDto == null)
            {
                return BadRequest();
            }

            var workspaceEntity = _mapper.Map<Entity.Workspace>(createDto);
            await _workspaceService.AddWorkSpace(workspaceEntity);
            return CreatedAtRoute("", workspaceEntity);
        }
    }
}
