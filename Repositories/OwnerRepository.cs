using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OwnerAPI.Contracts;
using OwnerAPI.Entities;

namespace OwnerAPI.Repositories
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOwner(Owner owner)
        {
            Create(owner);
        }

        public void DeleteOwner(Owner owner)
        {
            Delete(owner);
        }

        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            return await FindAll()
                        .ToListAsync();
        }

        public async Task<Owner> GetOwnerByIdAsync(Guid id)
        {
            return await FindByCondition(o => o.Id.Equals(id))
                        .FirstOrDefaultAsync();
        }

        public async Task<Owner> GetOwnerWithDetailsAsync(Guid id)
        {
            return await FindByCondition(o => o.Id.Equals(id))
                        .Include(o => o.Accounts)
                        .FirstOrDefaultAsync();
        }

        public void UpdateOwner(Owner owner)
        {
            Update(owner);
        }
    }
}