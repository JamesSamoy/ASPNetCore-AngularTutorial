using Microsoft.EntityFrameworkCore;

namespace SeedAPI.Data.Context
{
    public interface IApplicationContext
    {
        public DbSet<User> UsersDB { get; set; }

        public new void SaveChanges();

        public new DbSet<T> Set<T>() where T : class;

        public void BeginTransaction();

        public void CommitTransaction();

        public void RollbackTransaction();

        public void DisposeTransaction();
    }
}