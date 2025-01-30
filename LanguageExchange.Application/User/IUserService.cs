using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.User;

namespace LanguageExchange.Application.User
{
    public interface IUserService
    {
        ResultViewModel CreateUser(CreateUserInputModel userModel);
        ResultViewModel DeleteUser(int id);
        ResultViewModel UpdateUser(int id, CreateUserInputModel userModel);
        ResultViewModel<GetUserViewModel> GetUser(int id);
    }
}
