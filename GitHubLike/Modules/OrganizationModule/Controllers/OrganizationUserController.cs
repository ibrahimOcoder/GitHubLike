using AutoMapper;
using GitHubLike.Modules.OrganizationModule.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using GitHubLike.Modules.OrganizationModule.Entity;
using GitHubLike.Modules.OrganizationModule.Models;
using OrganizationRoles = GitHubLike.Modules.OrganizationModule.Types.OrganizationRoles;
using Microsoft.AspNetCore.Authorization;

namespace GitHubLike.Modules.OrganizationModule.Controllers
{
    [Authorize]
    [Route("api/organizationUser")]
    [ApiController]
    public class OrganizationUserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrganizationService _organizationService;
        private readonly IOrganizationUserService _organizationUserService;

        public OrganizationUserController(IMapper mapper, IOrganizationUserService organizationUserService, IOrganizationService organizationService)
        {
            _mapper = mapper;
            _organizationUserService = organizationUserService;
            _organizationService = organizationService;
        }

        [Route("GetOrganizationProjects")]
        [HttpGet("{id}/{userId}")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK, Type = typeof(List<OrganizationProjectsViewDto>))]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetOrganizationProjects([FromQuery] long id, [FromQuery] long userId)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var organizations = await _organizationService.GetOrganizationProjects(id, userId);

            if (organizations == null)
            {
                return NotFound();
            }

            return Ok(organizations);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddProjectUser([FromBody] OrganizationUserCreateDto createDto)
        {
            if (createDto == null)
            {
                return BadRequest();
            }

            var projectUser = _mapper.Map<OrganizationUsers>(createDto);

            var result = _organizationUserService.AddOrganizationUser(projectUser);

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
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OrganizationDetailViewDto))]
        public async Task<ActionResult> UpdateProjectUser([FromBody] OrganizationUserUpdateDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest();
            }

            var organizationUser = await _organizationUserService.GetOrganizationUser(updateDto.UserId, updateDto.OrganizationId);
            OrganizationRoles newRole;
            OrganizationRoles.TryParse(updateDto.RoleName, true, out newRole);
            if (newRole == null)
            {
                return BadRequest();
            }

            else
            {
                if (newRole == OrganizationRoles.Admin)
                {
                    newRole = OrganizationRoles.Member;
                }

                else
                {
                    newRole = OrganizationRoles.Admin;
                }
            }

            organizationUser.OrgRoleId = (int)newRole;

            var result = await _organizationUserService.UpdateOrganizationUser(organizationUser);

            if (result > 0)
            {
                var organizationUsers =
                    await _organizationService.GetOrganizationDetail(updateDto.OrganizationId, updateDto.UserId);
                return Ok(organizationUsers);
            }

            return Conflict();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OrganizationDetailViewDto))]
        public async Task<ActionResult> Delete([FromBody] OrganizationUserDeleteDto deleteDto)
        {
            if (deleteDto == null)
            {
                return BadRequest();
            }

            var organization = await _organizationUserService.GetOrganizationUser(deleteDto.UserId, deleteDto.OrganizationId);
            
            if (organization == null)
            {
                return NotFound();
            }

            long delete = await _organizationUserService.DeleteOrganizationUser(organization);

            if (delete > 0)
            {
                var organizationUsers =
                    await _organizationService.GetOrganizationDetail(deleteDto.OrganizationId, deleteDto.UserId);
                return Ok(organizationUsers);
            }

            return Conflict();
        }
    }
}
