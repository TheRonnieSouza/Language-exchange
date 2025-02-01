using LanguageExchange.Core.Entities;
using LanguageExchange.Core.Enum;
namespace LanguageExchange.Application.Models.UserServices
{
    public class CreateUserInputModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdSubscription { get; set; }
        public string Address { get;  set; }
        public string BirthDate { get;  set; }
        public string Phone { get;  set; }

        public User ToEntity() => new(Name, Email, Password, IdSubscription, Address,BirthDate, Phone);
    }
}
