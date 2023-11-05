using AutoMapper;
using GitHubLike.Modules.OrganizationModule.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using GitHubLike.Modules.OrganizationModule.Entity;
using GitHubLike.Modules.OrganizationModule.Models;

namespace GitHubLike.Modules.OrganizationModule.Controllers
{
    [Route("api/organizationUser")]
    [ApiController]
    public class OrganizationUserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrganizationUserService _organizationUserService;

        public OrganizationUserController(IMapper mapper, IOrganizationUserService organizationUserService)
        {
            _mapper = mapper;
            _organizationUserService = organizationUserService;
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
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateProjectUser([FromBody] OrganizationUserUpdateDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest();
            }

            var organizationUser = await _organizationUserService.GetOrganizationUser(updateDto.UserId, updateDto.OrganizationId);
            organizationUser.OrganizationRoleId = updateDto.OrganizationRoleId;

            var result = _organizationUserService.UpdateOrganizationUser(organizationUser);

            if (await result > 0)
            {
                return Ok();
            }

            return Conflict();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
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
                return Ok();
            }

            return Conflict();
        }
    }
}
