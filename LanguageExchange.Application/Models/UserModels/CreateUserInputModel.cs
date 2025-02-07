using LanguageExchange.Core.Entities;
namespace LanguageExchange.Application.Models.UserServices
{
    public class CreateUserInputModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public User ToEntity() => new(FullName, Email, PasswordHash);
    }
}
