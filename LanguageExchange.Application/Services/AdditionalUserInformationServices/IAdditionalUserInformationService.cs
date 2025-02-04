using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.UserAdditionalInfoModels;

namespace LanguageExchange.Application.Services.AdditionalUserInformationServices
{
    public interface IAdditionalUserInformationService
    {
        public Task<ResultViewModel<GetAdditionalInformationViewModel>> GetAdditionalInformation(Guid userId);
        public Task<ResultViewModel> UpdateAdditionalInformation(Guid userId, UpdateAdditionalUserInformationInputModel inputModel);
    }
}
