using System.ComponentModel.DataAnnotations;
using GitHubLike.Modules.RoleModule.Types;

namespace GitHubLike.Modules.RoleModule.Models
{
    public class RoleCreateDto
    {
        [Required] 
        public string RoleName { get; set; }

        [Required] 
        public Permissions Permissions { get; set; }

        public int UserId { get; set; }

    }
}
