using LanguageExchange.Core.Entities;
using LanguageExchange.Core.Enum;

namespace LanguageExchange.Application.Models.UserServices
{
    public class GetUserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserTypeEnum UserType { get;  set; }
        public DateTime RegistrationDate { get;  set; }
        public int IdSubscription { get;  set; }
        public bool IsActive { get;  set; }

        public static GetUserViewModel FromEntity(User result)
            => new()
            {
                Name = result.Name,
                Email = result.Email,
                UserType = result.UserType,
                RegistrationDate = result.RegistrationDate,
                IdSubscription = result.IdSubscription,
                IsActive = result.IsActive
            };
    }
}
