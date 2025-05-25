namespace LanguageExchange.Core.Entities
{
    public class Language
    {
        public Language(string nameOfLanguage)
        {
            NameOfLanguage = nameOfLanguage;
        }
        public string Id => _id.ToString();

        private Guid _id = Guid.NewGuid();
        public string NameOfLanguage { get; private set; } 

        public bool isActive { get; private set; } = true;

        public void Disable()
        {
            isActive = false;
        }
    }
}
