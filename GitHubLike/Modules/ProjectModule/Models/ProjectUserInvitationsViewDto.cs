namespace GitHubLike.Modules.ProjectModule.Models
{
    public class ProjectUserInvitationsViewDto
    {
        public ProjectViewDto Project { get; set; }

        public bool? InviteAccepted { get; set; }

        public string UserName { get; set; }
    }
}
