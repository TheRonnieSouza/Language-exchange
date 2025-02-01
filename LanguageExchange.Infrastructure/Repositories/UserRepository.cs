using LanguageExchange.Core.Entities;
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
        public async Task<int> AddUser(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteUser(int id)
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
        public async Task<User> GetUser(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                throw new Exception("User not found");
            }
            return result;
        }
        public async Task<bool> UpdateUser(int id, User user)
        {
             _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
