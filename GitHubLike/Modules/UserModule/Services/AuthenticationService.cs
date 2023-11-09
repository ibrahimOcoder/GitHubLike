using System.IdentityModel.Tokens.Jwt;
using GitHubLike.Modules.Common.Repository;
using GitHubLike.Modules.UserModule.Entity;
using GitHubLike.Modules.UserModule.Models;
using GitHubLike.Modules.UserModule.Repository;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GitHubLike.Modules.UserModule.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<User> _userRepository;

        public AuthenticationService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginResponseDto> Login(LoginDto loginDto)
        {
            var user = await _userRepository.Query().FirstOrDefaultAsync(u => u.Email == loginDto.UserId && u.UserPassword == ComputeHash(loginDto.Password));
            string token = "";

            if (user != null && user.Id > 0)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                string key = configuration["Jwt:Key"];
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(configuration["Jwt:Issuer"],
                    configuration["Jwt:Issuer"],
                    null,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);

                token = new JwtSecurityTokenHandler().WriteToken(Sectoken);    
            }

            var loginResponse = new LoginResponseDto
            {
                UserId = user.Id,
                Token = token
            };

            return loginResponse;
        }

        private string ComputeHash(string input)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder();
                foreach (var c in data)
                {
                    sb.Append(c.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
