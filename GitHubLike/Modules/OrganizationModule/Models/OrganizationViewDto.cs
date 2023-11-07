namespace GitHubLike.Modules.OrganizationModule.Models
{
    public class OrganizationViewDto
    {
        public long OrganizationId { get; set; }

        public string OrganizationName { get; set; }

        public DateOnly CreatedAt { get; set; }
    }
}
