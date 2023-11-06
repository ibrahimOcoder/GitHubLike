using GitHubLike.Modules.WorkspaceModule.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GitHubLike.Modules.Common.Entity
{

    public interface IEntityBase {}

    public abstract class EntityBase : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTimeOffset CreatedAt { get; protected set; } = DateTimeOffset.Now;

        public DateTimeOffset? UpdatedAt { get; protected set; }

        public bool SoftDeleted { get; set; } = false;

        public long? UpdatedBy { get; set; }
    }

    public abstract class EntityBaseWithWorkspace : EntityBase
    {
        
        [Required] 
        public Workspace Workspace { get; set; }

        [Required]
        public long WorkspaceId { get; set; }
    }
}
