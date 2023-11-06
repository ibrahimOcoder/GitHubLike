using System.ComponentModel.DataAnnotations.Schema;
using GitHubLike.Modules.Common.Entity;
using GitHubLike.Modules.RoleModule.Entity;
using GitHubLike.Modules.UserModule.Entity;
using Microsoft.EntityFrameworkCore;

namespace GitHubLike.Modules.ProjectModule.Entity
{
    [Table("ProjectModule_ProjectUsers")]
    [PrimaryKey(nameof(UserId), nameof(ProjectId), nameof(RoleId))]
    public class ProjectUsers : IEntityBase
    {
        public long UserId { get; set; }

        public User Users { get; set; }

        public long ProjectId { get; set; }

        public Projects Projects { get; set; }

        public long RoleId { get; set; }

        public Roles Roles { get; set; }

        public bool AcceptedInvite { get; set; }
    }
}
