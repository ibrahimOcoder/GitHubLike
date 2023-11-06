﻿using AutoMapper;
using GitHubLike.Modules.OrganizationModule.Repository;
using GitHubLike.Modules.ProjectModule.Models;
using GitHubLike.Modules.ProjectModule.Repository;
using GitHubLike.Modules.ProjectModule.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using GitHubLike.Modules.OrganizationModule.Models;

namespace GitHubLike.Modules.OrganizationModule.Controllers
{
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

        [HttpGet("/GetSharedOrganizationsByUserId/{id}")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK, Type = typeof(IQueryable<OrganizationUserInvitationsViewDto>))]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetSharedOrganizationsByUserId([FromBody] long id)
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
    }
}