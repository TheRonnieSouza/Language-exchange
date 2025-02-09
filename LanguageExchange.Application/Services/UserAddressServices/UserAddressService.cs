using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.UserAddressModels;
using LanguageExchange.Core.RepositoriesInterfaces;

namespace LanguageExchange.Application.Services.UserAddressServices
{
    public class UserAddressService : IUserAddressService
    {
        private readonly IUserAddressRepository _userAddressRepository; 

        public UserAddressService(IUserAddressRepository repository)
        {
            _userAddressRepository = repository;
        }
        public async Task<ResultViewModel<UserAddressViewModel>> GetAddress(Guid userId)
        {
            var address = await _userAddressRepository.GetUserAddress(userId);
            if (address == null)
                return ResultViewModel<UserAddressViewModel>.Error("Address not found.");

            var viewModel = UserAddressViewModel.FromEntity(address);            

            return ResultViewModel<UserAddressViewModel>.Success(viewModel);
        }
        public async Task<ResultViewModel<Guid>> CreateAddress(Guid userId, CreateUserAddressInputModel input)
        {
            var address = await _userAddressRepository.GetUserAddress(userId);
            if (address != null)
                return ResultViewModel<Guid>.Error($"Address already exist. Id {address.Id}");

            var userAddress = input.ToEntity(userId);
            var result = await _userAddressRepository.CreateUserAddress( userAddress);
            if (result == null)
                return ResultViewModel<Guid>.Error($"Error to create address, user: {userId}.");            

            return ResultViewModel<Guid>.Success(result);
        }

        public async Task<ResultViewModel<int>> UpdateAddress(Guid userId, UpdateUserAddressInputModel model)
        {
            var address = await _userAddressRepository.GetUserAddress(userId);
            if (address == null)
                return ResultViewModel<int>.Error("Address not found.");

            address.UpdateAddress(model.Zipcode, model.StreetName, model.HouseNumber,
                model.Country, model.State, model.City,
                model.Neighborhood, model.Complement);

            var result = await _userAddressRepository.UpdateUserAddress(userId,address);
            if (result == 0)
                return ResultViewModel<int>.Error("Update error.");

            return ResultViewModel<int>.Success(result);
        }

        public async Task<ResultViewModel<int>> DeleteAddress(Guid userId, Guid id)
        {
            var address = await _userAddressRepository.GetUserAddress(userId);
            if (address == null)
                return ResultViewModel<int>.Error("Address not found.");

            var result = await _userAddressRepository.DeleteUserAddress(id);
            if (result == 0)
                return ResultViewModel<int>.Error("Delete error.");

            return ResultViewModel<int>.Success(result);
        }       
    }
}
