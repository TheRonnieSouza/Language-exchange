using LanguageExchange.Core.Entities;
using LanguageExchange.Core.RepositoriesInterfaces;
using LanguageExchange.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LanguageExchange.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LanguageExchangeDbContext _context;
        public UserRepository(LanguageExchangeDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
        public async Task<bool> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;

            user.DeleteUser();
            await _context.SaveChangesAsync();

            if (user.IsActive)
                return false;

            return  true;
        }
        public async Task<User> GetUser(Guid id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                throw new Exception("User not found");
            }
            return result;
        }
        public async Task<bool> UpdateUser(Guid id, User user)
        {
             _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Guid> UpdateUserPassword(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
    }
}
