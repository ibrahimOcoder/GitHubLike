using GitHubLike.Modules.Common.Repository;
using GitHubLike.Modules.OrganizationModule.Entity;
using GitHubLike.Modules.OrganizationModule.Models;
using GitHubLike.Modules.OrganizationModule.Repository;
using GitHubLike.Modules.UserModule.Entity;
using Microsoft.EntityFrameworkCore;

namespace GitHubLike.Modules.OrganizationModule.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IRepository<Organizations> _organizationRepository;
        private readonly IRepository<OrganizationUsers> _organizationUsersRepository;
        private readonly IRepository<User> _userRepository;

        public OrganizationService(IRepository<Organizations> organizationRepository, IRepository<OrganizationUsers> organizationUsersRepository, IRepository<User> userRepository)
        {
            _organizationRepository = organizationRepository;
            _organizationUsersRepository = organizationUsersRepository;
            _userRepository = userRepository;
        }

        public async Task<Organizations> GetOrganization(long organizationId)
        {
            return await _organizationRepository.Query()
                .FirstOrDefaultAsync(p => p.Id == organizationId);
        }

        public async Task<List<OrganizationUserInvitationsViewDto>> GetOrganizationUserInvitations(long userId)
        {
            var sharedOrganizations = _organizationRepository.Query()
                .Join(_organizationUsersRepository.Query().Where(p => p.UserId == userId && p.AcceptedInvite != false),
                    organizations => organizations.Id,
                    organizationUsers => organizationUsers.OrganizationId,
                    (organizations, organizationUsers) => new { organizations, organizationUsers })
                .Join(_userRepository.Query(), 
                    combined => combined.organizations.OwnerUserId, user => user.Id,
                    (combined, user) => new OrganizationUserInvitationsViewDto
                    {
                        InviteAccepted = combined.organizationUsers.AcceptedInvite,
                        Organization = new OrganizationViewDto
                        {
                            OrganizationId = combined.organizations.Id,
                            OrganizationName = combined.organizations.OrganizationName,
                            CreatedAt = DateOnly.FromDateTime(combined.organizations.CreatedAt.DateTime)
                        },
                        UserName = user.UserName
                    }).AsNoTracking().ToList();


            var myOrganization = _organizationRepository.Query().FirstOrDefault(o => o.OwnerUserId == userId);
            sharedOrganizations.Add(new OrganizationUserInvitationsViewDto
            {
                InviteAccepted = true,
                Organization = new()
                {
                    OrganizationName = myOrganization.OrganizationName,
                    CreatedAt = DateOnly.FromDateTime(myOrganization.CreatedAt.DateTime),
                    OrganizationId = myOrganization.Id
                },
                UserName = "You"
            });

            return sharedOrganizations;
        }

        public async Task<int> AddOrganization(Organizations organization)
        {
            await _organizationRepository.Add(organization);
            return await _organizationRepository.SaveChanges();
        }
    }
}
