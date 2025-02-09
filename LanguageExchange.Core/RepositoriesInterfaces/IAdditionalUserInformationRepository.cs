using LanguageExchange.Core.Entities;

namespace LanguageExchange.Core.RepositoriesInterfaces
{
    public interface IAdditionalUserInformationRepository
    {
        Task<Guid> CreateAdditionalInformation(UserAdditionalInformation entity);
        public Task<UserAdditionalInformation> GetAdditionalInformation(Guid Id);
        public Task<bool> UpdateAdditionalInformation(Guid Id,UserAdditionalInformation userAdditionalInformation);
    }
}
