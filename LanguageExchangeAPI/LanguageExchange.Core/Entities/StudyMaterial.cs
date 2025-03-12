using LanguageExchange.Core.Enum;

namespace LanguageExchange.Core.Entities
{
    public class StudyMaterial
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string URL { get; private set; }
        public MaterialTypeEnum Material { get; private set; }
        public DateTime DataUpload { get; private set; }

        //TODO - Implementar métodos
        public void DownloadMaterial() { }
        public void DeleteMaterial() { }
    }
}
