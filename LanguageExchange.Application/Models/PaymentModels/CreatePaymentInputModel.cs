using LanguageExchange.Core.Entities;
using LanguageExchange.Core.Enum;

namespace LanguageExchange.Application.Models.PaymentModelsModels
{
    public class CreatePaymentInputModel
    {
        public int UserId { get; set; }
        public Subscription Subscription{ get; set; }
        public decimal Amount { get; set; } 
        public PaymentMethodEnum Method { get; set;}
        public  Payment ToEntity() => new Payment(UserId, Amount, Method);
    }
}
