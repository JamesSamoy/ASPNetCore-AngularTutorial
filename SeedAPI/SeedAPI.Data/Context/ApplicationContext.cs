using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace SeedAPI.Data.Context
{
    public class ApplicationContext : IdentityDbContext<User>, IApplicationContext
    {
        private IDbContextTransaction _dbContextTransaction;

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<User> UsersDB { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void BeginTransaction()
        {
            _dbContextTransaction = Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_dbContextTransaction != null)
            {
                _dbContextTransaction.Commit();
            }
        }

        public void RollbackTransaction()
        {
            if (_dbContextTransaction != null)
            {
                _dbContextTransaction.Rollback();
            }
        }

        public void DisposeTransaction()
        {
            if (_dbContextTransaction != null)
            {
                _dbContextTransaction.Dispose();
            }
        }
    }
}