using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.UserServices;

namespace LanguageExchange.Application.Services.UserServices
{
    public interface IUserService
    {
        Task<ResultViewModel<Guid>> CreateUser(CreateUserInputModel userModel);
        Task<ResultViewModel<Guid>> ChangePassword(Guid id, ChangePasswordInputModel newPassword);
        Task<ResultViewModel> DeleteUser(Guid id);
        Task<ResultViewModel> UpdateUser(Guid id, CreateUserInputModel userModel);
        Task<ResultViewModel<GetUserViewModel>> GetUser(Guid id);
    }
}
