using LanguageExchange.Core.Entities;
using LanguageExchange.Core.Enum;

namespace LanguageExchange.Application.Models.PaymentModels
{
    public class GetPaymentViewModel
    {
        public GetPaymentViewModel()
        {
        }
        public GetPaymentViewModel(int userId, decimal price, DateTime paymentDate, 
                                PaymentMethodEnum method,  PaymentMethodStatusEnum status)
        {
            UserId = userId;
            Price = price;
            PaymentDate = paymentDate;
            Method = method;
            Status = status;
        }
        public int UserId { get;  set; }
        public decimal Price { get;  set; }
        public DateTime PaymentDate { get;  set; }
        public PaymentMethodEnum Method { get;  set; }
        public PaymentMethodStatusEnum Status { get;  set; }
        public static GetPaymentViewModel FromEntity(Payment payment) =>
                    new(payment.UserId, payment.Price, payment.PaymentDate,
                        payment.Method, payment.Status);
    }
}
