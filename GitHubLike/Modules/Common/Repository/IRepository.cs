using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;

namespace GitHubLike.Modules.Common.Repository
{
    public interface IRepository<T> where T : class
    {

        DbSet<T> Query();

        EntityEntry<T> Entry(T entity);

        ValueTask<EntityEntry<T>> Add(T entity);

        Task AddRange(IEnumerable<T> entity);

        EntityEntry<T> Attach(T entity);

        void AttachRange(IEnumerable<T> entity);

        IDbContextTransaction BeginTransaction();

        Task<int> SaveChanges();

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        Task DeleteAll();

        DbContext GetContext();

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
