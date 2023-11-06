using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GitHubLike.Modules.Common.Entity;
using GitHubLike.Modules.OrganizationModule.Entity;
using GitHubLike.Modules.ProjectModule.Entity;
using GitHubLike.Modules.RoleModule.Entity;
using GitHubLike.Modules.WorkspaceModule.Entity;

namespace GitHubLike.Modules.UserModule.Entity
{
    [Table("UserModule_User")]
    public class User : EntityBaseWithWorkspace
    {
        [Required] 
        public string UserName { get; set; }

        [Required]
        public string UserPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<ProjectUsers> ProjectUsers { get; set; }

        public ICollection<OrganizationUsers> OrganizationUsers { get; set; }

        public ICollection<Roles> Roles { get; set; }
    }
}
