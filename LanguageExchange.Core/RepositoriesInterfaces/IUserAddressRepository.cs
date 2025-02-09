using LanguageExchange.Core.Entities;

namespace LanguageExchange.Core.RepositoriesInterfaces
{
    public interface IUserAddressRepository
    {
        Task<UserAddress> GetUserAddress(Guid userId);
        Task<Guid> CreateUserAddress( UserAddress userAddress);
        Task<int> UpdateUserAddress(Guid userId, UserAddress userAddress);
        Task<int> DeleteUserAddress( Guid id);

    }
}
