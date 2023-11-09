using System.Net;
using AutoMapper;
using GitHubLike.Modules.ProjectModule.Models;
using GitHubLike.Modules.ProjectModule.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GitHubLike.Modules.ProjectModule.Controllers
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

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK, Type = typeof(ProjectViewDto))]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetProject([FromBody] long projectId)
        {
            if (projectId == 0)
            {
                return BadRequest();
            }

            var project = await _projectService.GetProject(projectId);

            if (project == null)
            {
                return NotFound();
            }

            var projectViewDto = _mapper.Map<ProjectViewDto>(project);

            return Ok(projectViewDto);
        }

        [HttpGet("GetProjectsByUserId")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK, Type = typeof(IEnumerable<ProjectViewDto>))]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetProjectsByUserId([FromQuery] long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var projects = await _projectService.GetProjectsByOwner(id);

            if (projects == null)
            {
                return NotFound();
            }

            var projectViewDtos = _mapper.Map<IEnumerable<ProjectViewDto>>(projects);

            return Ok(projectViewDtos);
        }

        [HttpGet("GetSharedProjectsByUserId")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK, Type = typeof(IQueryable<ProjectUserInvitationsViewDto>))]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetSharedProjectsByUserId([FromQuery] long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var projects = await _projectService.GetProjectsByOwnerWithInvitations(id);

            if (projects == null)
            {
                return NotFound();
            }

            return Ok(projects);
        }

        [HttpGet("GetProjectDetails")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK, Type = typeof(IQueryable<ProjectDetailViewDto>))]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetProjectDetails([FromQuery] long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var projects = await _projectService.GetProjectDetails(id);

            if (projects == null)
            {
                return NotFound();
            }

            return Ok(projects);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Patch([FromBody] ProjectUpdateDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest();
            }

            var project = await _projectService.GetProject(updateDto.ProjectId);

            if (project == null)
            {
                return NotFound();
            }

            long update = await _projectService.UpdateProject(project);

            if (update > 0)
            {
                return Ok();
            }

            return Conflict();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Delete([FromBody] long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var roleEntity = await _projectService.GetProject(id);

            if (roleEntity == null)
            {
                return NotFound();
            }

            long delete = await _projectService.DeleteProject(roleEntity);

            if (delete > 0)
            {
                return Ok();
            }

            return Conflict();
        }
    }
}

