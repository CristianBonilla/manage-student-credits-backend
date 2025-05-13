using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace StudentCredits.Contracts.Repository;

public interface IRepositoryContext<in TContext> : IDisposable where TContext : DbContext
{
  DbSet<TEntity> Set<TEntity>() where TEntity : class;
  EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
  IDbContextTransaction BeginTransaction();
  Task<IDbContextTransaction> BeginTransactionAsync();
  int Save();
  Task<int> SaveAsync();
}
