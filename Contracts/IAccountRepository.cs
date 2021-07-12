using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OwnerAPI.Entities;

namespace OwnerAPI.Contracts
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(Guid id);
        Task<IEnumerable<Account>> GetAccountsByOwnerAsync(Guid ownerId);
        void CreateAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(Account account);
    }
}