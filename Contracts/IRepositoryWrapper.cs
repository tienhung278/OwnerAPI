using System.Threading.Tasks;

namespace OwnerAPI.Contracts
{
    public interface IRepositoryWrapper
    {
        public IOwnerRepository Owner { get; }
        public IAccountRepository Account { get; }
        Task SaveAsync();
    }
}