namespace GitHubLike.Modules.ProjectModule.Models
{
    public class ProjectViewDto
    {
        public long ProjectId { get; set; }

        public string ProjectName { get; set; }

        public DateOnly CreatedAt { get; set; }
    }
}
