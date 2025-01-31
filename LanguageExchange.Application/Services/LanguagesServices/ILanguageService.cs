using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.LanguagesModels;

namespace LanguageExchange.Application.Services.Language
{
    public interface ILanguageService
    {
        Task<ResultViewModel> AddLanguage(CreateLanguageInputModel languageModel);
        Task<ResultViewModel> DeleteLanguage(int id);
        Task<ResultViewModel<IList<GetAllLanguageViewModel>>> GetAllLanguages();
    }
}
