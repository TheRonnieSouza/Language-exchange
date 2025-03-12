using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.UserServices;
using LanguageExchange.Core.RepositoriesInterfaces;

namespace LanguageExchange.Application.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }   
        public async Task<ResultViewModel<Guid>> CreateUser(CreateUserInputModel userModel)
        {
            var model = userModel.ToEntity();
            var result = await _userRepository.AddUser(model);

            if (result == null)
                return ResultViewModel<Guid>.Error("Error creating user");

            return ResultViewModel<Guid>.Success(result);
        }
        public async Task<ResultViewModel<Guid>> ChangePassword(Guid id, ChangePasswordInputModel newPassword)
        {     
            var user = await _userRepository.GetUser(id);
            if (user == null)
                return ResultViewModel<Guid>.Error("User not found");

            if(!user.Authenticate(newPassword.CurrentPassword))
                return ResultViewModel<Guid>.Error("Invalid current password");

             user.UpdatePassword(newPassword.NewPassword);

            var result = await _userRepository.UpdateUserPassword(user);

            if (result != null)
                return ResultViewModel<Guid>.Error("Error to change password.");

            return ResultViewModel<Guid>.Success(result);
        }

        public async Task<ResultViewModel> DeleteUser(Guid id)
        {
            var result = await _userRepository.DeleteUser(id);

            if (!result)
                return ResultViewModel.Error("Error delete user");

            return ResultViewModel<Guid>.Success(id);
        }

        public async Task<ResultViewModel<GetUserViewModel>> GetUser(Guid id)
        {
            var result = await _userRepository.GetUser(id);

            if (result == null)
                return ResultViewModel<GetUserViewModel>.Error("Error get user");

            var model = GetUserViewModel.FromEntity(result);

            if (model == null)
                return ResultViewModel<GetUserViewModel>.Error("Error get user model");

            return ResultViewModel<GetUserViewModel>.Success(model);
        }

        public async Task<ResultViewModel> UpdateUser(Guid id, CreateUserInputModel userModel)
        {
            var user = await _userRepository.GetUser(id);

            if (user == null)
                return ResultViewModel.Error("Error get user");

            user.UpdateUser(userModel.FullName, userModel.Email);
            
            var result = await _userRepository.UpdateUser(id, user);

            if (!result)
                return ResultViewModel.Error("Error update user");

            return ResultViewModel<bool>.Success(result);
        }
    }
}
