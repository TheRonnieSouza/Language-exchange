using LanguageExchange.Core.Entities;

namespace LanguageExchange.Application.Models.LanguagesModels
{
    public class GetAllLanguageViewModel
    {
        public GetAllLanguageViewModel() { }
        public GetAllLanguageViewModel(string language) 
        {
            Languages.Add(language);
        }
        public IList<string> Languages { get; set; } = new List<string>();

        public static GetAllLanguageViewModel FromEntity(Language language) => new(language.NameOfLanguage);
    }
}
