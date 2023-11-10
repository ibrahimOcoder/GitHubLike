using GitHubLike.Modules.ProjectModule.Models;

namespace GitHubLike.Modules.OrganizationModule.Models
{
    public class OrganizationProjectsViewDto
    {
        public long ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string CreatedBy { get; set; }

        public DateOnly CreatedOn { get; set; }

        public List<ProjectUserDetailViewDto> OrganizationProjectUsers { get; set; }
    }
}
