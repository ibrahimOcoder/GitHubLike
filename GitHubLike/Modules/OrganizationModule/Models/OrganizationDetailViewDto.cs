namespace GitHubLike.Modules.OrganizationModule.Models
{
    public class OrganizationDetailViewDto
    {
        public string OrganizationName { get; set; }

        public List<OrganizationUserDetailViewDto> OrganizationUsersList { get; set; }

        public DateOnly CreatedOn { get; set; }

        public bool IsOwner { get; set; }

        public bool IsAdmin { get; set; }
    }

    public class OrganizationUserDetailViewDto
    {
        public long UserId { get; set; }

        public string UserName { get; set; }

        public string UserRole { get; set; }
    }
}
