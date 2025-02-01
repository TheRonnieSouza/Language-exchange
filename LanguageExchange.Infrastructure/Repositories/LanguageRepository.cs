using LanguageExchange.Core.Entities;
using LanguageExchange.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LanguageExchange.Infrastructure.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly LanguageExchangeDbContext _context;
        public LanguageRepository(LanguageExchangeDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Language language)
        {
            _context.Languages.Add(language);
            await _context.SaveChangesAsync();
            return language.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var language = await _context.Languages.FindAsync(id);
            if (language == null)
                return false;

            language.Disable();
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IList<Language>> GetAll()
        {
            return await _context.Languages.Where(l => l.isActive == true).ToListAsync();//await _context.Languages.ToListAsync();            
        }
    }
}
