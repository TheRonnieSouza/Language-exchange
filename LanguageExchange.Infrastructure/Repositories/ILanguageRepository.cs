using LanguageExchange.Core.Entities;

namespace LanguageExchange.Infrastructure.Repositories
{
    public interface ILanguageRepository
    {
        public Task<int> Add(Language language);
        public Task<bool> Delete(int id);
        public Task<IList<Language>> GetAll();
    }
}
