using LanguageExchange.Application.Models;
using LanguageExchange.Application.Models.Payment;

namespace LanguageExchange.Application.Services.Payment
{
    public interface IPaymentService
    {
        public ResultViewModel CreatePayment(CreatePaymentInputModel paymentModel);
        public ResultViewModel CancelPayment(int id, CancelPaymentInputModel paymentModel);

        public ResultViewModel<GetPaymentResultViewModel> GetPaymentStatus(int UserId, int PaymentId);
    }
}
