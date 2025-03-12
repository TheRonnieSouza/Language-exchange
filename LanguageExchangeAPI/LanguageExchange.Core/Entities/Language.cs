namespace LanguageExchange.Core.Entities
{
    public class Language
    {
        public Language(string nameOfLanguage)
        {
            NameOfLanguage = nameOfLanguage;
        }
        public int Id { get; private set; }
        public string NameOfLanguage { get; private set; } 

        public bool isActive { get; private set; } = true;

        public void Disable()
        {
            isActive = false;
        }
    }
}
