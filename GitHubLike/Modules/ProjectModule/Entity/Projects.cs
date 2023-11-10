using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GitHubLike.Modules.Common.Entity;
using GitHubLike.Modules.UserModule.Entity;

namespace GitHubLike.Modules.ProjectModule.Entity
{
    [Table("ProjectModule_Project")]
    public class Projects : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string ProjectName { get; set; }

        [Required] 
        public int OwnerTypeId { get; set; }

        public OwnerType OwnerTypes { get; set; }

        public int OwnerId { get; set; }

        public long CreatedByUserId { get; set; }

        public ICollection<ProjectUsers> ProjectUsers { get; set; }
    }
}
