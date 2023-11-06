using GitHubLike.Modules.UserModule.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using GitHubLike.Modules.Common.Entity;

namespace GitHubLike.Modules.OrganizationModule.Entity
{
    [Table("OrganizationModule_OrganizationUsers")]
    [PrimaryKey(nameof(UserId), nameof(OrganizationId), nameof(OrgRoleId))]
    public class OrganizationUsers : IEntityBase
    {
        public long UserId { get; set; }

        public User User { get; set; }

        public long OrganizationId { get; set; }

        public Organizations Organization { get; set; }

        public long OrgRoleId { get; set; }

        public OrganizationRoles OrganizationRole { get; set; }

        public bool? AcceptedInvite { get; set; } = null;
    }
}
