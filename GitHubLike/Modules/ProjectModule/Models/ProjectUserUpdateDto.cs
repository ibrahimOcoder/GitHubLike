namespace GitHubLike.Modules.ProjectModule.Models
{
    public class ProjectUserUpdateDto
    {
        public long UserId { get; set; }

        public long ProjectId { get; set; }

        public long RoleId { get; set; }
    }
}
