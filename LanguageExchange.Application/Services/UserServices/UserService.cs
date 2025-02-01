using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.UserServices;
using LanguageExchange.Infrastructure.Repositories;

namespace LanguageExchange.Application.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }   
        public async Task<ResultViewModel<int>> CreateUser(CreateUserInputModel userModel)
        {
            var model = userModel.ToEntity();
            var result = await _userRepository.AddUser(model);

            if (result == 0)
                return ResultViewModel<int>.Error("Error creating user");

            return ResultViewModel<int>.Success(result);
        }

        public async Task<ResultViewModel> DeleteUser(int id)
        {
            var result = await _userRepository.DeleteUser(id);

            if (!result)
                return ResultViewModel.Error("Error delete user");

            return ResultViewModel<int>.Success(id);
        }

        public async Task<ResultViewModel<GetUserViewModel>> GetUser(int id)
        {
            var result = await _userRepository.GetUser(id);

            if (result == null)
                return ResultViewModel<GetUserViewModel>.Error("Error get user");

            var model = GetUserViewModel.FromEntity(result);

            if (model == null)
                return ResultViewModel<GetUserViewModel>.Error("Error get user model");

            return ResultViewModel<GetUserViewModel>.Success(model);
        }

        public async Task<ResultViewModel> UpdateUser(int id, CreateUserInputModel userModel)
        {
            var user = await _userRepository.GetUser(id);

            if (user == null)
                return ResultViewModel.Error("Error get user");

            user.UpdateUser(userModel.Name, userModel.Email, userModel.Password,
                    userModel.Phone, userModel.Address, userModel.BirthDate);
            
            var result = await _userRepository.UpdateUser(id, user);

            if (!result)
                return ResultViewModel.Error("Error update user");

            return ResultViewModel<bool>.Success(result);
        }
    }
}
