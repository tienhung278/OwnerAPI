using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OwnerAPI.Contracts;
using OwnerAPI.Entities;

namespace OwnerAPI.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext context,
                                ILogger<AccountRepository> logger) : base(context, logger)
        {
        }

        public void CreateAccount(Account account)
        {
           Create(account);
        }

        public void DeleteAccount(Account account)
        {
            Delete(account);
        }

        public async Task<Account> GetAccountByIdAsync(Guid id)
        {
            return await FindByCondition(a => a.Id.Equals(id))
                        .FirstOrDefaultAsync();
        }

        public async Task<Account> GetAccountWithDetailsAsync(Guid id)
        {
            return await FindByConditionWithDetails(a => a.Id.Equals(id), "Owner")
                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Account>> GetAccountsByOwnerAsync(Guid ownerId)
        {
            return await FindByCondition(a => a.OwnerId.Equals(ownerId))
                        .ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await FindAll()
                    .ToListAsync();
        }

        public void UpdateAccount(Account account)
        {
            Update(account);
        }
    }
}