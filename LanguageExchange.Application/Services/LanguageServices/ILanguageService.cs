using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.LanguagesModels;

namespace LanguageExchange.Application.Services.LanguageServices
{
    public interface ILanguageService
    {
        Task<ResultViewModel<string>> AddLanguage(CreateLanguageInputModel languageModel);
        Task<ResultViewModel> DeleteLanguage(string id);
        Task<ResultViewModel<IList<GetAllLanguageViewModel>>> GetAllLanguages();
    }
}
