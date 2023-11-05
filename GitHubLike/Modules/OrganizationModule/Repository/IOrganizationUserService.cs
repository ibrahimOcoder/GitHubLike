using GitHubLike.Modules.OrganizationModule.Entity;
using GitHubLike.Modules.OrganizationModule.Models;

namespace GitHubLike.Modules.OrganizationModule.Repository
{
    public interface IOrganizationUserService
    {
        Task<OrganizationUsers> GetOrganizationUser(long userId, long organizationId);

        Task<int> AddOrganizationUser(OrganizationUsers organizationUser);

        Task<int> UpdateOrganizationUser(OrganizationUsers organizationUser);

        Task<int> DeleteOrganizationUser(OrganizationUsers organizationUser);
    }
}
