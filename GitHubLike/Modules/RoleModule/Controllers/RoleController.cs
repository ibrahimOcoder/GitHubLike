using System.ComponentModel;
using AutoMapper;
using GitHubLike.Modules.RoleModule.Repository;
using GitHubLike.Modules.WorkspaceModule.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using GitHubLike.Modules.RoleModule.Entity;
using GitHubLike.Modules.RoleModule.Models;
using GitHubLike.Modules.WorkspaceModule.Services;
using Microsoft.AspNetCore.Http.HttpResults;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GitHubLike.Modules.RoleModule.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoleService _rolesService;

        public RoleController(IMapper mapper, IRoleService roleService)
        {
            _mapper = mapper;
            _rolesService = roleService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.Created, Type = typeof(RoleViewDto))]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult> Get(long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var roleEntity = await _rolesService.GetRole(id);

            if (roleEntity == null)
            {
                return NotFound();
            }

            return Ok(roleEntity);
        }

        [HttpGet("/GetRolesByUserId/{id}")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.Created, Type = typeof(IEnumerable<RoleViewDto>))]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetRolesByUserId(long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var roleEntities = await _rolesService.GetRolesByUser(id);

            if (roleEntities == null)
            {
                return NotFound();
            }

            var roleViewDtos = _mapper.Map<IEnumerable<RoleViewDto>>(roleEntities);

            return Ok(roleViewDtos);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.Created, Type = typeof(RoleViewDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post([FromBody] RoleCreateDto createDto)
        {
            long? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return Unauthorized();
            }

            if (createDto == null)
            {
                return BadRequest();
            }

            var roleEntity = _mapper.Map<Roles>(createDto);
            roleEntity.CreatedByUserId = (long)userId;

            await _rolesService.AddRole(roleEntity);

            var roleViewDto = _mapper.Map<RoleViewDto>(roleEntity);
            return CreatedAtRoute("", roleViewDto);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Patch(long id, [FromBody] RoleUpdateDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest();
            }

            var roleEntity = await _rolesService.GetRole(id);

            if (roleEntity == null)
            {
                return NotFound();
            }

            long update = await _rolesService.UpdateRole(roleEntity);

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
        public async Task<ActionResult> Delete(long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var roleEntity = await _rolesService.GetRole(id);

            if (roleEntity == null)
            {
                return NotFound();
            }

            long delete = await _rolesService.DeleteRole(roleEntity);

            if (delete > 0)
            {
                return Ok();
            }

            return Conflict();
        }
    }
}
