using System.ComponentModel.DataAnnotations;
using GitHubLike.Modules.Common.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace GitHubLike.Modules.WorkspaceModule.Entity
{
    [Table("WorkspaceModule_Workspace")]
    public class Workspace : EntityBase
    {
        [MaxLength(50)]
        [Required]
        public string WorkspaceName { get; set; }
    }
}
