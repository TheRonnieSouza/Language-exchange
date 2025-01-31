using LanguageExchange.Core.Entities;

namespace LanguageExchange.Application.Models.LanguagesModels
{
    public class CreateLanguageInputModel
    {
        public CreateLanguageInputModel(string nameOfLanguage)
        {
            NameOfLanguage = nameOfLanguage;
        }
        public  static string NameOfLanguage { get; set; }
        public static Language ToEntity() => new Language(NameOfLanguage);
    }
}
