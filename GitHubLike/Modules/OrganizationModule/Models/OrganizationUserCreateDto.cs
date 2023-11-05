namespace GitHubLike.Modules.OrganizationModule.Models
{
    public class OrganizationUserCreateDto
    {
        public long OrganizationId { get; set; }

        public long UserId { get; set; }

        public long OrganizationRoleId { get; set; }
    }
}
