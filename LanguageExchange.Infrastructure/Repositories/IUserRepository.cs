using LanguageExchange.Core.Entities;

namespace LanguageExchange.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        public Task<int> AddUser(User user);
        public Task<bool> DeleteUser(int id);
        public Task<User> GetUser(int id);
        public Task<bool> UpdateUser(int id, User user);
    }
}
