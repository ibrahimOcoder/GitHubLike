using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GitHubLike.Modules.Common.Entity;

namespace GitHubLike.Modules.Project.Entity
{
    [Table("ProjectModule_Project")]
    public class Projects : EntityBaseWithWorkspace
    {
        [Required]
        [MaxLength(50)]
        public string ProjectName { get; set; }

        [Required] 
        public int OwnerTypeId { get; set; }

        public List<OwnerType> OwnerTypes { get; set; }
    }
}
