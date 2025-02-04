using LanguageExchange.Core.Entities;
using LanguageExchange.Core.Enum;

namespace LanguageExchange.Application.Models.UserAdditionalInfoModels
{
    public class GetAdditionalInformationViewModel
    {
        public GetAdditionalInformationViewModel(Guid userId, string phone, DateTime birthDate, UserTypeEnum userType,
                                                string gender, string profilePictureUrl, string socialMidiaUrl)
        {
            UserId = userId;
            Phone = phone;
            BirthDate = birthDate;
            UserType = userType;
            Gender = gender;
            ProfilePictureUrl = profilePictureUrl;
            SocialMidiaUrl = socialMidiaUrl;
        }
        public Guid UserId { get; private set; }
        public string Phone { get; private set; }
        public DateTime BirthDate { get; private set; }
        public UserTypeEnum UserType { get; private set; }
        public string Gender { get; private set; }
        public string ProfilePictureUrl { get; private set; }
        public string SocialMidiaUrl { get; private set; }
        public static GetAdditionalInformationViewModel FromEntity(UserAdditionalInformation result) =>
            new(result.UserId, result.Phone, result.BirthDate, 
                result.UserType, result.Gender, result.ProfilePictureUrl, result.SocialMidiaUrl);       
    }
}
