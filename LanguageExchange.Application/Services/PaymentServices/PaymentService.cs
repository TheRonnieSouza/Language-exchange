using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.PaymentModels;
using LanguageExchange.Application.Models.PaymentModelsModels;
using LanguageExchange.Core.RepositoriesInterfaces;

namespace LanguageExchange.Application.Services.PaymentServices
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<ResultViewModel> CreatePayment(CreatePaymentInputModel paymentModel)
        {
            var payment = paymentModel.ToEntity();

            string id = await _paymentRepository.Add(payment);

            if(string.IsNullOrEmpty(id)) 
                return ResultViewModel.Error("Error creating payment");

            return ResultViewModel<string>.Success(id);
        }
        public async Task<ResultViewModel> CancelPayment(string id, CancelPaymentInputModel paymentModel)
        {
            var result = await _paymentRepository.Cancel(id);

            if(!result)
                return ResultViewModel.Error("Error cancel payment");

            return ResultViewModel<bool>.Success(result);
        }
        public async Task<ResultViewModel<GetPaymentViewModel>> GetPaymentStatus(string UserId, string PaymentId)
        {
            var payment = await _paymentRepository.GetPayment(UserId, PaymentId);

            if(payment == null)
                return ResultViewModel<GetPaymentViewModel>.Error("Error get payment");

            var model = GetPaymentViewModel.FromEntity(payment);

            var result = ResultViewModel<GetPaymentViewModel>.Success(model);
            return result;
        }
    }
}
