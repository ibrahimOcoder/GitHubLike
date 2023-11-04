using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GitHubLike.Modules.Common.Entity
{
    [Table("OwnerType")]
    public class OwnerType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        public bool SoftDeleted { get; set; } = false;
    }
}
