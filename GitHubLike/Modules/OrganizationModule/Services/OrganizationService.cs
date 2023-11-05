using GitHubLike.Modules.Common.Repository;
using GitHubLike.Modules.OrganizationModule.Entity;
using GitHubLike.Modules.OrganizationModule.Models;
using GitHubLike.Modules.OrganizationModule.Repository;
using Microsoft.EntityFrameworkCore;

namespace GitHubLike.Modules.OrganizationModule.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IRepository<Organizations> _organizationRepository;
        private readonly IRepository<OrganizationUsers> _organizationUsersRepository;

        public OrganizationService(IRepository<Organizations> organizationRepository, IRepository<OrganizationUsers> organizationUsersRepository)
        {
            _organizationRepository = organizationRepository;
            _organizationUsersRepository = organizationUsersRepository;
        }

        public async Task<Organizations> GetOrganization(long organizationId)
        {
            return await _organizationRepository.Query()
                .FirstOrDefaultAsync(p => p.Id == organizationId);
        }

        public async Task<IQueryable<OrganizationUserInvitationsViewDto>> GetOrganizationUserInvitations(long userId)
        {
            return _organizationRepository.Query().Join(_organizationUsersRepository.Query().Where(p => p.UserId == userId && p.AcceptedInvite == false),
                 organizations => organizations.Id,
                 organizationUsers => organizationUsers.OrganizationId,
                 (organizations, organizationUsers) => new OrganizationUserInvitationsViewDto
                 {
                     InviteAccepted = organizationUsers.AcceptedInvite,
                     Organization = new OrganizationViewDto { OrganizationId = organizations.Id, OrganizationName = organizations.OrganizationName }
                 }).AsNoTracking();
        }

        public async Task<int> AddOrganization(Organizations organization)
        {
            await _organizationRepository.Add(organization);
            return await _organizationRepository.SaveChanges();
        }
    }
}
