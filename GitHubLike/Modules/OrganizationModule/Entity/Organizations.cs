using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GitHubLike.Modules.Common.Entity;
using GitHubLike.Modules.UserModule.Entity;

namespace GitHubLike.Modules.OrganizationModule.Entity
{
    [Table("OrganizationModule_Organization")]
    public class Organizations : EntityBaseWithWorkspace
    {
        [Required]
        [MaxLength(50)]
        public string OrganizationName { get; set; }

        [Required] 
        public User OwnerUser { get; set; }

        [Required]
        public long OwnerUserId { get; set; }

        public ICollection<OrganizationUsers> OrganizationUsers { get; set; }
    }
}
