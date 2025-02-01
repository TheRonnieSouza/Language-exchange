using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.UserServices;

namespace LanguageExchange.Application.Services.UserServices
{
    public interface IUserService
    {
        Task<ResultViewModel<int>> CreateUser(CreateUserInputModel userModel);
        Task<ResultViewModel> DeleteUser(int id);
        Task<ResultViewModel> UpdateUser(int id, CreateUserInputModel userModel);
        Task<ResultViewModel<GetUserViewModel>> GetUser(int id);
    }
}
