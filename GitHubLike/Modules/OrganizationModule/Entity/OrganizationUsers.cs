using GitHubLike.Modules.UserModule.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using GitHubLike.Modules.Common.Entity;

namespace GitHubLike.Modules.OrganizationModule.Entity
{
    [Table("OrganizationModule_OrganizationUsers")]
    [PrimaryKey(nameof(UserId), nameof(OrganizationId), nameof(OrganizationRoleId))]
    public class OrganizationUsers : IEntityBase
    {
        public long UserId { get; set; }

        public List<User> Users { get; set; }

        public long OrganizationId { get; set; }

        public List<Organizations> Organizations { get; set; }

        public long OrganizationRoleId { get; set; }

        public List<OrganizationRoles> OrganizationRoles { get; set; }

        public bool AcceptedInvite { get; set; }
    }
}
