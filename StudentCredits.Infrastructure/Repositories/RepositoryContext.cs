using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using StudentCredits.Contracts.Repository;

namespace StudentCredits.Infrastructure.Repositories;

public abstract class RepositoryContext<TContext>(TContext context) : IRepositoryContext<TContext> where TContext : DbContext
{
  readonly TContext _context = context;
  bool _disposed = false;

  public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
  {
    return _context.Entry(entity);
  }

  public DbSet<TEntity> Set<TEntity>() where TEntity : class
  {
    return _context.Set<TEntity>();
  }

  public IDbContextTransaction BeginTransaction() => _context.Database.BeginTransaction();

  public Task<IDbContextTransaction> BeginTransactionAsync() => _context.Database.BeginTransactionAsync();

  public int Save() => _context.SaveChanges();

  public Task<int> SaveAsync() => _context.SaveChangesAsync();

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (_disposed)
      return;
    if (disposing)
      _context.Dispose();
    _disposed = true;
  }
}
