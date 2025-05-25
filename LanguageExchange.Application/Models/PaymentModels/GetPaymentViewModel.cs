using LanguageExchange.Core.Entities;
using LanguageExchange.Core.Enum;

namespace LanguageExchange.Application.Models.PaymentModels
{
    public class GetPaymentViewModel
    {
        public GetPaymentViewModel()
        {
        }
        public GetPaymentViewModel(string userId, decimal price, DateTime paymentDate, 
                                PaymentMethodEnum method, PaymentStatus status)
        {
            UserId = userId;
            Price = price;
            PaymentDate = paymentDate;
            Method = method;
            Status = status;
        }
        public string  UserId { get;  set; }
        public decimal Price { get;  set; }
        public DateTime PaymentDate { get;  set; }
        public PaymentMethodEnum Method { get;  set; }
        public PaymentStatus Status { get;  set; }
        public static GetPaymentViewModel FromEntity(Payment payment) =>
                    new GetPaymentViewModel (payment.UserId.ToString(), payment.Amount, payment.TransactionDate,
                        payment.Method, payment.Status);
    }
}
