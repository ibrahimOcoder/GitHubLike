namespace GitHubLike.Modules.ProjectModule.Models
{
    public class ProjectUserCreateDto
    {
        public long ProjectId { get; set; }

        public long UserId { get; set; }

        public long RoleId { get; set; }
    }
}
