using System.Threading.Tasks;
using OwnerAPI.Contracts;

namespace OwnerAPI.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext context;
        private IOwnerRepository owner;
        private IAccountRepository account;

        public RepositoryWrapper(RepositoryContext context)
        {
            this.context = context;
        }

        public IOwnerRepository Owner
        {
            get
            {
                if (owner == null)
                {
                    owner = new OwnerRepository(context);
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
                    account = new AccountRepository(context);
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