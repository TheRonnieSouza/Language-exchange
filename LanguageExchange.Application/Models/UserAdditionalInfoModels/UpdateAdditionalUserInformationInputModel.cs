using LanguageExchange.Core.Enum;

namespace LanguageExchange.Application.Models.UserAdditionalInfoModels
{
    public class UpdateAdditionalUserInformationInputModel
    {
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string SocialMidiaUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
