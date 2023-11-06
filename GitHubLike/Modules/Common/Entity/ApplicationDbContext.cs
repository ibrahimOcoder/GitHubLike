using Microsoft.EntityFrameworkCore;
using System.Reflection;
using GitHubLike.Modules.OrganizationModule.Entity;
using GitHubLike.Modules.ProjectModule.Entity;
using GitHubLike.Modules.RoleModule.Entity;
using GitHubLike.Modules.UserModule.Entity;

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

            modelBuilder.Entity<Projects>()
                .HasMany(e => e.ProjectUsers)
                .WithOne(e => e.Projects)
                .HasForeignKey(e => e.ProjectId)
                .IsRequired();

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.ProjectUsers)
                .WithOne(e => e.Roles)
                .HasForeignKey(e => e.RoleId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(e => e.ProjectUsers)
                .WithOne(e => e.Users)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            modelBuilder.Entity<Organizations>()
                .HasMany(e => e.OrganizationUsers)
                .WithOne(e => e.Organization)
                .HasForeignKey(e => e.OrganizationId)
                .IsRequired();

            modelBuilder.Entity<OrganizationRoles>()
                .HasMany(e => e.OrganizationUsers)
                .WithOne(e => e.OrganizationRole)
                .HasForeignKey(e => e.OrgRoleId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(e => e.OrganizationUsers)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            modelBuilder.Entity<Roles>()
                .HasOne(p => p.CreatedBy)
                .WithMany(q => q.Roles)
                .HasForeignKey(r => r.CreatedByUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
