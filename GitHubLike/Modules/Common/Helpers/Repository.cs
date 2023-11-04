using GitHubLike.Modules.Common.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using GitHubLike.Modules.Common.Entity;

namespace GitHubLike.Modules.Common.Helpers
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public ChangeTracker ChangeTracker => Context.ChangeTracker;
        protected ApplicationDbContext Context { get; }
        protected DbSet<T> DbSet { get; }

        public Repository(ApplicationDbContext context) {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public ValueTask<EntityEntry<T>> Add(T entity) {
            return DbSet.AddAsync(entity);
        }

        public Task AddRange(IEnumerable<T> entity) {
            return DbSet.AddRangeAsync(entity);
        }

        public EntityEntry<T> Attach(T entity) {
            return DbSet.Attach(entity);
        }

        public void AttachRange(IEnumerable<T> entity) {
            DbSet.AttachRange(entity);
        }

        public IDbContextTransaction BeginTransaction() {
            return Context.Database.BeginTransaction();
        }

        public async Task DeleteAll() {
            if (await Query().AnyAsync()) {
                DbSet.RemoveRange(Query());
            }
        }

        public void DetachAllEntities() {
            var changedEntriesCopy = ChangeTracker.Entries()
                                                  .Where(e => e.State == EntityState.Added ||
                                                              e.State == EntityState.Modified ||
                                                              e.State == EntityState.Deleted)
                                                  .ToList();

            foreach (var entity in changedEntriesCopy) {
                Context.Entry(entity.Entity).State = EntityState.Detached;
            }
        }

        public string GetTableName() {
            return FindTableEntity().GetTableName();
        }

        public IEntityType FindTableEntity() {
            return Context.Model.FindEntityType(typeof(T));
        }

        public EntityEntry<T> Entry(T entity) {
            return Context.Entry(entity);
        }

        public DbContext GetContext() {
            return Context;
        }

        public DbSet<T> Query() {
            return DbSet;
        }

        public void Remove(T entity) {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities) {
             DbSet.RemoveRange(entities);
        }

        public Task<int> SaveChanges() {
            return Context.SaveChangesAsync();
        }

        public void Update(T entity) {
            DbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities) {
            DbSet.UpdateRange(entities);
        }

        public Task<IDbContextTransaction> BeginTransactionAsync() {
            return GetContext().Database.BeginTransactionAsync();
        }
    }
}
