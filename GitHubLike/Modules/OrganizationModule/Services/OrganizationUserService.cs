using GitHubLike.Modules.Common.Repository;
using GitHubLike.Modules.OrganizationModule.Entity;
using GitHubLike.Modules.OrganizationModule.Repository;
using Microsoft.EntityFrameworkCore;

namespace GitHubLike.Modules.OrganizationModule.Services
{
    public class OrganizationUserService : IOrganizationUserService
    {
        private readonly IRepository<OrganizationUsers> _organizationUsersRepository;

        public OrganizationUserService(IRepository<OrganizationUsers> organizationUsersRepository)
        {
            _organizationUsersRepository = organizationUsersRepository;
        }

        public async Task<OrganizationUsers> GetOrganizationUser(long userId, long organizationId)
        {
            return await _organizationUsersRepository.Query()
                .FirstOrDefaultAsync(p => p.UserId == userId && p.OrganizationId == organizationId);
        }

        public async Task<int> AddOrganizationUser(OrganizationUsers organizationUser)
        {
            await _organizationUsersRepository.Add(organizationUser);
            return await _organizationUsersRepository.SaveChanges();
        }

        public async Task<int> UpdateOrganizationUser(OrganizationUsers organizationUser)
        {
            _organizationUsersRepository.Update(organizationUser);
            return await _organizationUsersRepository.SaveChanges();
        }

        public async Task<int> DeleteOrganizationUser(OrganizationUsers organizationUser)
        {
            _organizationUsersRepository.Remove(organizationUser);
            return await _organizationUsersRepository.SaveChanges();
        }
    }
}
