namespace GitHubLike.Modules.OrganizationModule.Models
{
    public class OrganizationUserInvitationsViewDto
    {
        public OrganizationViewDto Organization { get; set; }

        public bool? InviteAccepted { get; set; }
    }
}
