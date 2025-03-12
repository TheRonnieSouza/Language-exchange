using LanguageExchange.Core.Entities;

namespace LanguageExchange.Application.Models.UserServices
{
    public class GetUserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get;  set; }
        public bool IsActive { get;  set; }

        public static GetUserViewModel FromEntity(User result)
            => new()
            {
                Name = result.FullName,
                Email = result.Email,
                CreatedAt = result.CreatedAt,
                IsActive = result.IsActive
            };
    }
}
