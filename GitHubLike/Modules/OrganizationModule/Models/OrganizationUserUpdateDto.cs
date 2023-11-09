namespace GitHubLike.Modules.OrganizationModule.Models
{
    public class OrganizationUserUpdateDto
    {
        public long OrganizationId { get; set; }

        public long UserId { get; set; }

        public string RoleName { get; set; } = "";
    }
}
