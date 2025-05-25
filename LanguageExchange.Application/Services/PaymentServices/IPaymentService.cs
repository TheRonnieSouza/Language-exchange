using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.PaymentModels;
using LanguageExchange.Application.Models.PaymentModelsModels;

namespace LanguageExchange.Application.Services.PaymentServices
{
    public interface IPaymentService
    {
        public Task<ResultViewModel> CreatePayment(CreatePaymentInputModel paymentModel);
        public Task<ResultViewModel> CancelPayment(string id, CancelPaymentInputModel paymentModel);
        public Task<ResultViewModel<GetPaymentViewModel>> GetPaymentStatus(string UserId, string PaymentId);
    }    
}
