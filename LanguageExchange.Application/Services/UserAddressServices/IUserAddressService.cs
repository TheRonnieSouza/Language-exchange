using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.UserAddressModels;

namespace LanguageExchange.Application.Services.UserAddressServices
{
    public interface IUserAddressService
    {
        Task<ResultViewModel<UserAddressViewModel>> GetAddress(Guid userId);
        Task<ResultViewModel<Guid>> CreateAddress(Guid userId, CreateUserAddressInputModel input);
        Task<ResultViewModel<int>> UpdateAddress(Guid userId, UpdateUserAddressInputModel input);
        Task<ResultViewModel<int>> DeleteAddress(Guid userId, Guid id);
    }
}
