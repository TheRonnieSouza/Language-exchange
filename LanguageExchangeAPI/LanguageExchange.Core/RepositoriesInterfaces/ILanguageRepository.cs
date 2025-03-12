using LanguageExchange.Core.Entities;

namespace LanguageExchange.Core.RepositoriesInterfaces
{
    public interface ILanguageRepository
    {
        public Task<int> Add(Language language);
        public Task<bool> Delete(int id);
        public Task<IList<Language>> GetAll();
    }
}
