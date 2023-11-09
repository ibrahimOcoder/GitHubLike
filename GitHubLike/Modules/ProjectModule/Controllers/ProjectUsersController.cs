using System.Net;
using AutoMapper;
using GitHubLike.Modules.ProjectModule.Entity;
using GitHubLike.Modules.ProjectModule.Models;
using GitHubLike.Modules.ProjectModule.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GitHubLike.Modules.ProjectModule.Controllers
{
    [Authorize]
    [Route("api/projectUsers")]
    [ApiController]
    public class ProjectUsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProjectService _projectService;
        private readonly IProjectUsersService _projectUsersService;

        public ProjectUsersController(IMapper mapper, IProjectUsersService projectUsersService, IProjectService projectService)
        {
            _mapper = mapper;
            _projectService = projectService;
            _projectUsersService = projectUsersService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddProjectUser([FromBody] ProjectUserCreateDto createDto)
        {
            if (createDto == null)
            {
                return BadRequest();
            }

            var projectUser = _mapper.Map<ProjectUsers>(createDto);

            var result = _projectUsersService.AddProjectUser(projectUser);

            if (await result > 0)
            {
                return Ok();
            }

            return Conflict();
        }

        [HttpPatch]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IQueryable<ProjectUserInvitationsViewDto>))]
        public async Task<ActionResult> UpdateProjectUser([FromBody] ProjectUserUpdateDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest();
            }

            var projectUser = await _projectUsersService.GetProjectUser(updateDto.UserId, updateDto.ProjectId);

            if (updateDto.RoleId > 0)
            {
                projectUser.RoleId = updateDto.RoleId;    
            }
            
            projectUser.AcceptedInvite = updateDto.AcceptedInvite;

            var result = await _projectUsersService.UpdateProjectUserRole(projectUser);

            if (result > 0)
            {
                var projectInvites = await _projectService.GetProjectsByOwnerWithInvitations(updateDto.UserId);
                return Ok(projectInvites);
            }

            return Conflict();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProjectDetailViewDto))]
        public async Task<ActionResult> Delete([FromBody] ProjectUserDeleteDto deleteDto)
        {
            if (deleteDto == null)
            {
                return BadRequest();
            }

            var projectUser = await _projectUsersService.GetProjectUser(deleteDto.UserId, deleteDto.ProjectId);

            if (projectUser == null)
            {
                return NotFound();
            }

            long delete = await _projectUsersService.DeleteProjectUser(projectUser);

            if (delete > 0)
            {
                var projectUsers = await _projectService.GetProjectDetails(deleteDto.ProjectId);
                return Ok(projectUsers);
            }

            return Conflict();
        }
    }
}
