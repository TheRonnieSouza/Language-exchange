using LanguageExchange.Core.Enum;

namespace LanguageExchange.Core.Entities
{
    public class UserAdditionalInformation
    {
        public UserAdditionalInformation() { }
        public UserAdditionalInformation(Guid userId, string phone, DateTime birthDate, UserTypeEnum userType, string gender = null, string profilePictureUrl = null, string socialMidiaUrl = null)
        {
            UserId = userId;
            Phone = phone;
            BirthDate = birthDate;
            UserType = userType;
            Gender = gender;
            ProfilePictureUrl = profilePictureUrl;
            SocialMidiaUrl = socialMidiaUrl;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid UserId { get; private set; }
        public string Phone { get; private set; }
        public DateTime BirthDate { get; private set; }
        public UserTypeEnum UserType { get; private set; }
        public string Gender { get; private set; }         
        public string ProfilePictureUrl { get; private set; }
        public string SocialMidiaUrl { get; private set; }

        public User User { get; private set; }

        public void UpdateInformation(string phone, DateTime birthDate, UserTypeEnum userType, string gender = null, string profilePictureUrl = null,string socialMidiaUrl =null)
        {           
            Phone = phone;
            BirthDate = birthDate;
            UserType = userType;
            Gender = gender;
            ProfilePictureUrl = profilePictureUrl;
            SocialMidiaUrl = socialMidiaUrl;
        }
    }
}
