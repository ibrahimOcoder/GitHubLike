using GitHubLike.Modules.UserModule.Models;

namespace GitHubLike.Modules.UserModule.Repository
{
    public interface IAuthenticationService
    {
        Task<LoginResponseDto> Login(LoginDto loginDto);
    }
}
