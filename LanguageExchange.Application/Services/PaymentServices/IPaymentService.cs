using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.PaymentModels;
using LanguageExchange.Application.Models.PaymentModelsModels;
using LanguageExchange.Infrastructure.Repositories;

namespace LanguageExchange.Application.Services.PaymentServices
{
    public interface IPaymentService
    {
        public Task<ResultViewModel> CreatePayment(CreatePaymentInputModel paymentModel);
        public Task<ResultViewModel> CancelPayment(int id, CancelPaymentInputModel paymentModel);
        public Task<ResultViewModel<GetPaymentViewModel>> GetPaymentStatus(int UserId, int PaymentId);
    }    
}
