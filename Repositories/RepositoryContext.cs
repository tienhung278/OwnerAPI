using Microsoft.EntityFrameworkCore;
using OwnerAPI.Entities;

namespace OwnerAPI.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}