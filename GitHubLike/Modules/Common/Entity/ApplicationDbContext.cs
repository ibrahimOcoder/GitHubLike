using GitHubLike.Modules.WorkspaceModule.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using GitHubLike.Modules.Common.Repository;
using System.Diagnostics;
using GitHubLike.Modules.Common.Helpers;
using GitHubLike.Modules.Organization.Entity;
using GitHubLike.Modules.RoleModule.Entity;
using GitHubLike.Modules.UserModule.Entity;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GitHubLike.Modules.Common.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            var entityTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => typeof(IEntityBase).IsAssignableFrom(type) && !type.IsAbstract);

            foreach (var entityType in entityTypes)
            {
                var method = typeof(ModelBuilder).GetMethod("Entity", new Type[] { });
                var genericMethod = method.MakeGenericMethod(entityType);
                genericMethod.Invoke(modelBuilder, null);
            }
        }
    }
}
