using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.LanguagesModels;
using LanguageExchange.Application.Services.LanguageServices;
using LanguageExchange.Core.RepositoriesInterfaces;

namespace LanguageExchange.Application.Services.Language
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }
       
        public async Task<ResultViewModel> DeleteLanguage(string id)
        {
            var result = await _languageRepository.Delete(id);

            return ResultViewModel<string>.Success(id);
        }       

        public async Task<ResultViewModel<IList<GetAllLanguageViewModel>>> GetAllLanguages()
        {
            var languages = await _languageRepository.GetAll();
            var model =  languages.Select(GetAllLanguageViewModel.FromEntity).ToList();

            var result = ResultViewModel<IList<GetAllLanguageViewModel>>.Success(model);

            return  result;
        }

        public async Task<ResultViewModel<string>> AddLanguage(CreateLanguageInputModel languageModel)
        {
            var language = languageModel.ToEntity();

            string id = await _languageRepository.Add(language);

            return ResultViewModel<string>.Success(id);
        }
    }
}
