using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.UserAdditionalInfoModels;
using LanguageExchange.Core.RepositoriesInterfaces;

namespace LanguageExchange.Application.Services.AdditionalUserInformationServices
{
    public class AdditionalUserInformationService : IAdditionalUserInformationService
    {
        private readonly IAdditionalUserInformationRepository _additionalUserInformationRepository;

        public AdditionalUserInformationService(IAdditionalUserInformationRepository additionalUserInformationRepository)
        {
            _additionalUserInformationRepository = additionalUserInformationRepository;
        }

        public async Task<ResultViewModel<Guid>> CreateAdditionalInformation(Guid userId, CreateAdditionalUserInformationInputModel input)
        {
            var addInformation = await _additionalUserInformationRepository.GetAdditionalInformation(userId);
            if (addInformation != null)
                return ResultViewModel<Guid>.Error($"Additional information already exist. Id {addInformation.Id}");

            var entity = input.ToEntity(userId);
            var result = await _additionalUserInformationRepository.CreateAdditionalInformation(entity);
            if (result == null)
                return ResultViewModel<Guid>.Error($"Error to create additional information, user: {userId}.");

            return ResultViewModel<Guid>.Success(result);
        }

        public async Task<ResultViewModel<GetAdditionalInformationViewModel>> GetAdditionalInformation(Guid userId)
        {
            var user = await _additionalUserInformationRepository.GetAdditionalInformation(userId);
            if(user == null)
                return ResultViewModel<GetAdditionalInformationViewModel>.Error("User don't have additional information" );

            var model = GetAdditionalInformationViewModel.FromEntity(user);

            return ResultViewModel<GetAdditionalInformationViewModel>.Success(model);
        }

        public async Task<ResultViewModel> UpdateAdditionalInformation(Guid userId,
                                        UpdateAdditionalUserInformationInputModel model)
        {
            var user = await _additionalUserInformationRepository.GetAdditionalInformation(userId);
            if (user == null)
                return ResultViewModel<GetAdditionalInformationViewModel>.Error("User not found");

            user.UpdateInformation(model.Phone, model.BirthDate, model.UserType, model.Gender,
                model.ProfilePictureUrl, model.SocialMidiaUrl);

            var result = await _additionalUserInformationRepository.UpdateAdditionalInformation(userId,user);
           
            if(!result)
                return ResultViewModel.Error("Error updating user information");

            return ResultViewModel.Success();
        }
    }
}
