using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.PaymentMethodModels;

namespace LanguageExchange.Application.Services.PaymentMethodServices
{
    public interface IPaymentMethodService
    {
        Task<ResultViewModel<GetPaymentMethodViewModel>> GetPaymentMethod(Guid userId);
        Task<ResultViewModel<GetPaymentMethodViewModel>> UpdatePaymentMethod(Guid userId, UpdatePaymentMethodInputModel model);
        Task<ResultViewModel<GetPaymentMethodViewModel>> CreatePaymentMethod(Guid userId, CreatePaymentMethodInputModel model);
        Task<ResultViewModel> CancelPaymentMethod(Guid id, Guid userId);

    }
}
