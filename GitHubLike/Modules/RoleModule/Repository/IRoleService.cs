using GitHubLike.Modules.RoleModule.Entity;

namespace GitHubLike.Modules.RoleModule.Repository
{
    public interface IRoleService
    {
        Task AddRole(Roles role);

        Task<Roles> GetRole(long roleId);

        Task<int> UpdateRole(Roles role);

        Task<int> DeleteRole(Roles role);
    }
}
