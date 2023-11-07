using GitHubLike.Modules.OrganizationModule.Entity;
using GitHubLike.Modules.OrganizationModule.Models;

namespace GitHubLike.Modules.OrganizationModule.Repository
{
    public interface IOrganizationService
    {
        Task<Organizations> GetOrganization(long organizationId);

        Task<List<OrganizationUserInvitationsViewDto>> GetOrganizationUserInvitations(long userId);

        Task<int> AddOrganization(Organizations organization);
    }
}
