using LanguageExchange.Core.Enum;

namespace LanguageExchange.Core.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserTypeEnum UserType { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public PlanEnum? Subscription { get; private set; }

        //TODO - Implementar métodos
        public void Authenticate() { }
        public void UpdateUser() { }

    }
}
