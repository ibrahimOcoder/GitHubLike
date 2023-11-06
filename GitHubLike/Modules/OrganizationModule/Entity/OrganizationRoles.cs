using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GitHubLike.Modules.Common.Entity;

namespace GitHubLike.Modules.OrganizationModule.Entity
{
    [Table("OrganizationModule_OrganizationRoles")]
    public class OrganizationRoles : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string OrganizationRoleName { get; set; }

        public bool SoftDeleted { get; set; } = false;

        public ICollection<OrganizationUsers> OrganizationUsers { get; set; }
    }
}
