using LanguageExchange.Core.Entities;

namespace LanguageExchange.Core.RepositoriesInterfaces
{
    public interface IUserRepository
    {
        public Task<Guid> AddUser(User user);
        public Task<bool> DeleteUser(Guid id);
        public Task<User> GetUser(Guid id);
        public Task<bool> UpdateUser(Guid id, User user);
        Task<Guid> UpdateUserPassword(User user);
    }
}
