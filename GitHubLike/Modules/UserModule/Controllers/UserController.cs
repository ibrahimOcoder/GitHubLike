using GitHubLike.Modules.OrganizationModule.Models;
using GitHubLike.Modules.UserModule.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using GitHubLike.Modules.UserModule.Models;

namespace GitHubLike.Modules.UserModule.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public UserController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK, Type = typeof(LoginResponseDto))]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest();
            }

            var loginResponseDto = await _authenticationService.Login(loginDto);

            if (loginResponseDto.Token == "")
            {
                return NotFound();
            }

            return Ok(loginResponseDto);
        }
    }
}
