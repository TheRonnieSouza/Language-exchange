namespace LanguageExchange.Application.Models.UserServices
{
    public class ChangePasswordInputModel
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
