using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OwnerAPI.Entities;

namespace OwnerAPI.Contracts
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllOwnersAsync();
        Task<Owner> GetOwnerByIdAsync(Guid id);
        Task<Owner> GetOwnerWithDetailsAsync(Guid id);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }
}