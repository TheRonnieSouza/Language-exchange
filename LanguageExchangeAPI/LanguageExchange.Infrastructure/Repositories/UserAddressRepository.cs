using LanguageExchange.Core.Entities;
using LanguageExchange.Core.RepositoriesInterfaces;
using LanguageExchange.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LanguageExchange.Infrastructure.Repositories
{
    public class UserAddressRepository : IUserAddressRepository
    {
        private readonly LanguageExchangeDbContext _context;
        public UserAddressRepository(LanguageExchangeDbContext context) 
        {
            _context = context;
        }

        public async Task<Guid> CreateUserAddress( UserAddress NewUserAddress)
        {
            await _context.UserAddress.AddAsync(NewUserAddress);
            await _context.SaveChangesAsync();
            return NewUserAddress.Id;
        }

        public async Task<int> DeleteUserAddress(Guid id)
        {
           var userAddress = await _context.UserAddress.FirstOrDefaultAsync(ua => ua.Id == id && ua.IsActive);
            if (userAddress == null)
                return 0;
            userAddress.DesactiveAddress();

            return await _context.SaveChangesAsync();
        }

        public async Task<UserAddress> GetUserAddress(Guid userId)
        {
            return await _context.UserAddress.FirstOrDefaultAsync(ua => ua.UserId == userId && ua.IsActive);
        }

        public async Task<int> UpdateUserAddress(Guid userId, UserAddress NewUserAddress)
        {
            var address = await _context.UserAddress.FirstOrDefaultAsync(ua => ua.UserId == userId && ua.IsActive);

                address.UpdateAddress(NewUserAddress.Zipcode, NewUserAddress.StreetName, NewUserAddress.HouseNumber,
                        NewUserAddress.Country, NewUserAddress.State, NewUserAddress.City,
                        NewUserAddress.Neighborhood, NewUserAddress.Complement);

             _context.Update(address);
            return await _context.SaveChangesAsync();
        }
    }
}
