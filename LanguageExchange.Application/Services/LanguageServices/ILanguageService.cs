using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.LanguagesModels;

namespace LanguageExchange.Application.Services.LanguageServices
{
    public interface ILanguageService
    {
        Task<ResultViewModel<int>> AddLanguage(CreateLanguageInputModel languageModel);
        Task<ResultViewModel> DeleteLanguage(int id);
        Task<ResultViewModel<IList<GetAllLanguageViewModel>>> GetAllLanguages();
    }
}
