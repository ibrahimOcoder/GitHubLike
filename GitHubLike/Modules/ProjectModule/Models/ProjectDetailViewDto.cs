namespace GitHubLike.Modules.ProjectModule.Models
{
    public class ProjectDetailViewDto
    {
        public string ProjectName { get; set; }

        public List<ProjectUserDetailViewDto> ProjectUsersList { get; set; }

        public DateOnly CreatedOn { get; set; }
    }

    public class ProjectUserDetailViewDto
    {
        public long UserId { get; set; }

        public string UserName { get; set; }
    }
}
