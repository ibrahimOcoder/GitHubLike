using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GitHubLike.Modules.Common.Entity;
using GitHubLike.Modules.WorkspaceModule.Entity;

namespace GitHubLike.Modules.UserModule.Entity
{
    [Table("UserModule_User")]
    public class User : EntityBase
    {
        [Required] 
        public string UserName { get; set; }

        [Required]
        public string UserPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required] 
        public Workspace Workspace { get; set; }

        [Required]
        public long WorkspaceId { get; set; }
    }
}
