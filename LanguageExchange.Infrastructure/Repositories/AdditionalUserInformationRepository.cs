using LanguageExchange.Core.Entities;
using LanguageExchange.Core.RepositoriesInterfaces;
using LanguageExchange.Infrastructure.Persistence;

namespace LanguageExchange.Infrastructure.Repositories
{
    public class AdditionalUserInformationRepository : IAdditionalUserInformationRepository
    {
        private readonly LanguageExchangeDbContext _context;

        public AdditionalUserInformationRepository(LanguageExchangeDbContext context)
        {
            _context = context;
        }
        public async Task<UserAdditionalInformation> GetAdditionalInformation(Guid Id)
        {
            var result = await _context.UserAdditionalInformations.FindAsync(Id);
            return result;
        }

        public async Task<bool> UpdateAdditionalInformation(Guid Id,UserAdditionalInformation userAdditionalInformation)
        {
            var user = await _context.UserAdditionalInformations.FindAsync(userAdditionalInformation.Id);
            
            if (user == null)
                return false;

            user = userAdditionalInformation;
            user.UpdateInformation(userAdditionalInformation.Phone, userAdditionalInformation.BirthDate, userAdditionalInformation.UserType, userAdditionalInformation.Gender,
                userAdditionalInformation.ProfilePictureUrl, userAdditionalInformation.SocialMidiaUrl);
            _context.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
