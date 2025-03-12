using LanguageExchange.Core.Entities;

namespace LanguageExchange.Application.Models.LanguagesModels
{
    public class CreateLanguageInputModel
    {
        public CreateLanguageInputModel(string nameOfLanguage)
        {
            NameOfLanguage = nameOfLanguage;
        }
        public  string NameOfLanguage { get; set; }
        public  Language ToEntity() => new Language(NameOfLanguage);
    }
}
