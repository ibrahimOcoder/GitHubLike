using GitHubLike.Modules.OrganizationModule.Entity;
using GitHubLike.Modules.OrganizationModule.Models;

namespace GitHubLike.Modules.OrganizationModule.Repository
{
    public interface IOrganizationService
    {
        Task<Organizations> GetOrganization(long organizationId);

        Task<OrganizationDetailViewDto> GetOrganizationDetail(long organizationId, long userId);

        Task<List<OrganizationUserInvitationsViewDto>> GetOrganizationUserInvitations(long userId);

        Task<List<OrganizationProjectsViewDto>> GetOrganizationProjects(long organizationId, long userId);

        Task<int> AddOrganization(Organizations organization);
    }
}
