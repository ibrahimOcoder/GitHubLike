using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
