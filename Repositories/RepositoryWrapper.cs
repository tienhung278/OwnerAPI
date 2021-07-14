using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OwnerAPI.Contracts;

namespace OwnerAPI.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext context;
        private readonly ILogger<OwnerRepository> ownerLogger;
        private readonly ILogger<AccountRepository> accountLogger;
        private IOwnerRepository owner;
        private IAccountRepository account;

        public RepositoryWrapper(RepositoryContext context,
                                ILogger<OwnerRepository> ownerLogger,
                                ILogger<AccountRepository> accountLogger)
        {
            this.context = context;
            this.ownerLogger = ownerLogger;
            this.accountLogger = accountLogger;
        }

        public IOwnerRepository Owner
        {
            get
            {
                if (owner == null)
                {
                    owner = new OwnerRepository(context, ownerLogger);
                }
                return owner;
            }            
        }

        public IAccountRepository Account
        {
            get
            {
                if (account == null)
                {
                    account = new AccountRepository(context, accountLogger);
                }
                return account;
            }
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}