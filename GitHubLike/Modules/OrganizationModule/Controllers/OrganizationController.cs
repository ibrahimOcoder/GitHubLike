using AutoMapper;
using GitHubLike.Modules.OrganizationModule.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using GitHubLike.Modules.OrganizationModule.Models;
using Microsoft.AspNetCore.Authorization;

namespace GitHubLike.Modules.OrganizationModule.Controllers
{
    [Authorize]
    [Route("api/organization")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IMapper mapper, IOrganizationService organizationService)
        {
            _mapper = mapper;
            _organizationService = organizationService;
        }

        [HttpGet("GetSharedOrganizationsByUserId")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK, Type = typeof(IQueryable<OrganizationUserInvitationsViewDto>))]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetSharedOrganizationsByUserId([FromQuery] long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var organizations = await _organizationService.GetOrganizationUserInvitations(id);

            if (organizations == null)
            {
                return NotFound();
            }

            return Ok(organizations);
        }

        [HttpGet("/{id}/{userId}")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK, Type = typeof(OrganizationDetailViewDto))]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetOrganizationDetail([FromQuery] long id, [FromQuery] long userId)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var organizations = await _organizationService.GetOrganizationDetail(id, userId);

            if (organizations == null)
            {
                return NotFound();
            }

            return Ok(organizations);
        }
    }
}
