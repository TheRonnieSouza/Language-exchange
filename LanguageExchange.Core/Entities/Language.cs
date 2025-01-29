namespace LanguageExchange.Core.Entities
{
    public class Language
    {
        public int Id { get; private set; }
        public List<string> NameOfLanguage { get; private set; } = new List<string>();
    }
}
