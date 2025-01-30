using LanguageExchange.Core.Enum;

namespace LanguageExchange.Application.Models.User
{
    public class GetUserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserTypeEnum UserType { get;  set; }
        public DateTime RegistrationDate { get;  set; }
        public PlanEnum? Subscription { get;  set; }
        public bool IsActive { get;  set; }
    }
}
