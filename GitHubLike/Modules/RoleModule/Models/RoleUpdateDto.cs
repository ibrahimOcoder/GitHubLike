using GitHubLike.Modules.RoleModule.Types;
using System.ComponentModel.DataAnnotations;

namespace GitHubLike.Modules.RoleModule.Models
{
    public class RoleUpdateDto
    {
        public string RoleName { get; set; }

        public Permissions Permissions { get; set; }
    }
}
