using GitHubLike.Modules.Common.Repository;
using GitHubLike.Modules.RoleModule.Entity;
using GitHubLike.Modules.RoleModule.Repository;
using GitHubLike.Modules.WorkspaceModule.Entity;
using Microsoft.EntityFrameworkCore;

namespace GitHubLike.Modules.RoleModule.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Roles> _roleRepository;

        public RoleService(IRepository<Roles> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task AddRole(Roles role)
        {
            await _roleRepository.Add(role);
            await _roleRepository.SaveChanges();
        }

        public async Task<Roles> GetRole(long roleId)
        {
            return await _roleRepository.Query().SingleOrDefaultAsync(r => r.Id == roleId);
        }

        public async Task<IQueryable<Roles>> GetRolesByUser(long userId)
        {
            return _roleRepository.Query().Where(r => r.CreatedByUserId == userId).AsNoTracking();
        }

        public async Task<int> UpdateRole(Roles role)
        {
            _roleRepository.Update(role);
            return await _roleRepository.SaveChanges();
        }

        public async Task<int> DeleteRole(Roles role)
        {
            _roleRepository.Remove(role);
            return await _roleRepository.SaveChanges();
        }
    }
}
