using LanguageExchange.Core.Entities;
using LanguageExchange.Core.Enum;

namespace LanguageExchange.Application.Models.PaymentModels
{
    public class CancelPaymentInputModel
    {
        public int UserId { get; set; }
        public Subscription Subscription { get; set; }
        public int Amount { get; set; }
        public PaymentMethodEnum Method { get; set; }

    }
}
