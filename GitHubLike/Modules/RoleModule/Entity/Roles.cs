using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GitHubLike.Modules.Common.Entity;
using GitHubLike.Modules.RoleModule.Types;

namespace GitHubLike.Modules.RoleModule.Entity
{
    [Table("RoleModule_Roles")]
    public class Roles : EntityBase
    {
        [MaxLength(50)]
        [Required]
        public string RoleName { get; set; }

        [Required]
        public Permissions Permissions { get; set; }
    }
}
