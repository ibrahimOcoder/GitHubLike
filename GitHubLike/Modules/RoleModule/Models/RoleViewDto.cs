using GitHubLike.Modules.RoleModule.Types;
using System.ComponentModel.DataAnnotations;

namespace GitHubLike.Modules.RoleModule.Models
{
    public class RoleViewDto
    {
        [Required] 
        public string RoleName { get; set; }

        [Required] 
        public Permissions Permissions { get; set; }
    }
}
