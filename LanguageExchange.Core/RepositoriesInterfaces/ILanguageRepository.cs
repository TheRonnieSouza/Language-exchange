using LanguageExchange.Core.Entities;

namespace LanguageExchange.Core.RepositoriesInterfaces
{
    public interface ILanguageRepository
    {
        public Task<string> Add(Language language);
        public Task<bool> Delete(string id);
        public Task<IList<Language>> GetAll();
    }
}
