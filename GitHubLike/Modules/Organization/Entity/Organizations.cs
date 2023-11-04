using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GitHubLike.Modules.Common.Entity;
using GitHubLike.Modules.WorkspaceModule.Entity;

namespace GitHubLike.Modules.Organization.Entity
{
    [Table("OrganizationModule_Organization")]
    public class Organizations : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string OrganizationName { get; set; }

        [Required] 
        public Workspace Workspace { get; set; }

        [Required]
        public long WorkspaceId { get; set; }
    }
}
