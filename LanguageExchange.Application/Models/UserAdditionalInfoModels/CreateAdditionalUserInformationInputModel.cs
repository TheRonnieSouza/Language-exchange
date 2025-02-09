using LanguageExchange.Core.Entities;
using LanguageExchange.Core.Enum;

namespace LanguageExchange.Application.Models.UserAdditionalInfoModels
{
    public class CreateAdditionalUserInformationInputModel
    {
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string SocialMidiaUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public UserTypeEnum UserType { get; set; }

        public UserAdditionalInformation ToEntity(Guid userId)
        {
            return new UserAdditionalInformation(
                userId,
                Phone,
                BirthDate,
                UserType,
                Gender,
                ProfilePictureUrl,
                SocialMidiaUrl
                );
        }
    }
}
