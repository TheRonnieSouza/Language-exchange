using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.PaymentMethodModels;
using LanguageExchange.Application.Services.PaymentMethodServices;

namespace LanguageExchange.Application.Services.PaymentServices
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodService _paymentRepository;
        public PaymentMethodService(IPaymentMethodService paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public Task<ResultViewModel> CancelPaymentMethod(Guid id, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ResultViewModel<GetPaymentMethodViewModel>> CreatePaymentMethod(Guid userId, CreatePaymentMethodInputModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ResultViewModel<GetPaymentMethodViewModel>> GetPaymentMethod(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ResultViewModel<GetPaymentMethodViewModel>> UpdatePaymentMethod(Guid userId, UpdatePaymentMethodInputModel model)
        {
            throw new NotImplementedException();
        }
       
    }
}
